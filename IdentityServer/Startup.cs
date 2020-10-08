using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer.Resources;
using IdentityServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

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
            services.AddCors(config =>
                config.AddPolicy(
                    "AllowAll",
                    p =>
                        p.AllowCredentials()
                            .WithOrigins(
                                "http://localhost:3000",
                                "https://localhost:3001",
                                "https://localhost:5001")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                )
            );


            services.AddDbContext<AppDbContext>(config => { config.UseSqlite(_config.GetConnectionString("DataBase")); });

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
            AddLocalizationConfigurations(services);

            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryApiScopes(Configuration.GetApis())
                .AddInMemoryClients(Configuration.GetClients())
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddDeveloperSigningCredential();
            // .AddSigningCredential(certificate);

            services.AddAuthentication()
                .AddFacebook(config =>
                {
                    config.ClientId = _config["AuthClients:Google:ClientId"];
                    config.ClientSecret = _config["AuthClients:Google:ClientSecret"];
                });

            services.Configure<SmtpSettings>(_config.GetSection("SmtpSettings"));
            services.AddSingleton<IMailerService, MailerService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                })
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseCors("AllowAll");

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    if (context.Context.Response.Headers["feature-policy"].Count == 0)
                    {
                        var featurePolicy = "accelerometer 'none'; camera 'none'; geolocation 'none'; gyroscope 'none'; magnetometer 'none'; microphone 'none'; payment 'none'; usb 'none'";

                        context.Context.Response.Headers["feature-policy"] = featurePolicy;
                    }

                    if (context.Context.Response.Headers["X-Content-Security-Policy"].Count == 0)
                    {
                        var csp = "script-src 'self';style-src 'self';img-src 'self' data:;font-src 'self';form-action 'self';frame-ancestors 'self';block-all-mixed-content";
                        // IE
                        context.Context.Response.Headers["X-Content-Security-Policy"] = csp;
                    }
                }
            });

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }


        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                var user = new IdentityUser("bob") {Email = "andreas@butzhammer.de", EmailConfirmed = true};
                userManager.CreateAsync(user, "Pass123$").GetAwaiter().GetResult();
            }
        }

        private static void AddLocalizationConfigurations(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("de-DE")
                    };

                    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;

                    var providerQuery = new LocalizationQueryProvider
                    {
                        QueryParameterName = "ui_locales"
                    };

                    options.RequestCultureProviders.Insert(0, providerQuery);
                });
        }
    }
}