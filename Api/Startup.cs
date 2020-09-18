using System;
using Api.Communication.Hubs;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Dal;
using Dal.Interfaces.Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

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
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config =>
                {
                    config.Authority = "https://localhost:5003/";
                    config.Audience = "Api_CodersShop";
                    config.RequireHttpsMetadata = false;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
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

            services.AddSingleton<IContextFactory>(new ContextFactory(_configuration["Paths:DataBase"]));

            services.AddControllers();

            ConfigureAutomapper(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseWebSockets();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ProductHub>("ProductHub");
            });


            DataBaseMigration.EnsureMigrated(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider, _configuration["Paths:DataBase"]).Wait();
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