using System.IO;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer.Services;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = _config.GetConnectionString("DataBase");

            services.AddDbContext<AppDbContext>(config => { config.UseSqlite(dbConnectionString); });

            services.AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });

            var filePath = Path.Combine(_env.ContentRootPath, "is_cert.pfx");
            var certificate = new X509Certificate2(filePath, _config["Passwords:Certificate"]);

            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryApiScopes(Configuration.GetApis())
                .AddInMemoryClients(Configuration.GetClients())
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddSigningCredential(certificate);
            // .AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddFacebook( config =>
                {
                    config.ClientId = _config["AuthClients:Google:ClientId"];
                    config.ClientSecret = _config["AuthClients:Google:ClientSecret"];
                    config.ClaimActions.MapJsonKey("urn:facebook:email", "email", "string");
                });

            services.Configure<SmtpSettings>(_config.GetSection("SmtpSettings"));
            services.AddSingleton<IMailerService, MailerService>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }


        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                var user = new IdentityUser("bob");
                userManager.CreateAsync(user, "Pass123$").GetAwaiter().GetResult();
                userManager.AddClaimAsync(user, new Claim("rc.garndma", "big.cookie"))
                    .GetAwaiter().GetResult();
                userManager.AddClaimAsync(user,
                        new Claim("rc.api.garndma", "big.api.cookie"))
                    .GetAwaiter().GetResult();
            }
        }
    }
}