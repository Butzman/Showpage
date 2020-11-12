using System.Threading.Tasks;
using Api.Communication.Hubs;
using Api.Communication.Interfaces;
using Api.Communication.Services;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Backend_Shared.Interfaces.DataServices;
using Backend_Shared.Interfaces.DbServices;
using Backend_Shared.Services.DataServices;
using Dal;
using Dal.Interfaces.Dal;
using Dal.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Shared.Helpers;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.Authority = "https://localhost:5003/";
                    config.Audience = "Api_CodersShop";
                    config.RequireHttpsMetadata = false;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                    };
                    config.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Query["access_token"];
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddCors(config =>
                config.AddPolicy(
                    "CorsPolicy",
                    p =>
                        p.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                )
            );

            services.AddControllers();

            RegisterIoc(services);
            ConfigureAutomapper(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseWebSockets();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ProductHub>("/" + SignalrUrls.ProductsHub);
                endpoints.MapHub<CartHub>("/" + SignalrUrls.CartsHub);
            });


            DataBaseMigration.EnsureMigrated(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider, _configuration["Paths:DataBase"]).Wait();
        }


        private void RegisterIoc(IServiceCollection services)
        {
            services.AddSingleton<IContextFactory>(new ContextFactory(_configuration["Paths:DataBase"]));

            var productDataService = new ProductDataService();
            services.AddSingleton<IProductObservable>(productDataService);
            services.AddSingleton<IProductDataService>(productDataService);

            services.AddSingleton<IProductDbService, ProductDbService>();
            services.AddSingleton<IProductPublishService, ProductPublishService>();

            
            var cartDataService = new CartDataService();
            services.AddSingleton<ICartObservable>(cartDataService);
            services.AddSingleton<ICartDataService>(cartDataService);

            services.AddSingleton<ICartDbService, CartDbService>();
            services.AddSingleton<ICartPublishService, CartPublishService>();
        }

        public static void ConfigureAutomapper(IServiceCollection services)
        {
            var configurationProvider = new MapperConfiguration(x =>
            {
                x.AddProfile<AutomapperProfile>();
                x.AddProfile<Dal.AutomapperProfile>();
                x.AddCollectionMappers();
            });
            var mapper = new Mapper(configurationProvider);
            services.AddSingleton<IMapper>(mapper);
        }
    }
}