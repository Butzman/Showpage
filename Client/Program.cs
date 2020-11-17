using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using BlazorClient.Logic.Interfaces.Communication.Hub;
using BlazorClient.Logic.Interfaces.DataServices;
using BlazorClient.Logic.Services.Communication.HubServices;
using BlazorClient.Logic.Services.DataServices;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage();

            IocSetUp(builder);

            var authorityUrl = builder.Configuration.GetValue<string>("Urls:IdentityServer");
            var clientUrl = builder.Configuration.GetValue<string>("Urls:Client");
            Console.WriteLine(clientUrl);
            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.ClientId = "blazor_client";
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.Authority = authorityUrl;
                options.ProviderOptions.RedirectUri = clientUrl + "authentication/login-callback";
                options.ProviderOptions.PostLogoutRedirectUri = clientUrl;

                options.ProviderOptions.DefaultScopes.Add("openid profile email");
                options.AuthenticationPaths.RemoteRegisterPath = authorityUrl + "auth/register";
                options.AuthenticationPaths.RemoteProfilePath = authorityUrl + "manage/index";
                options.AuthenticationPaths.LogInPath = authorityUrl + "auth/login";
                options.AuthenticationPaths.LogOutPath = authorityUrl + "auth/logout";
            });

            await builder.Build().RunAsync();
        }

        private static void IocSetUp(WebAssemblyHostBuilder builder)
        {
            var services = builder.Services;

            services.AddHttpContextAccessor();

            var apiUrl = builder.Configuration.GetValue<string>("Urls:Api");
            services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(apiUrl)});

            services.AddBlazoredToast();

            services.AddScoped<IProductHubService, ProductHubService>();
            services.AddScoped<IProductDataService, ProductDataService>();

            services.AddScoped<ICartDataService, CartDataService>();
            services.AddScoped<ICartHubService, CartHubService>();

            ConfigureAutomapper(services);
        }

        private static void ConfigureAutomapper(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(x => x.AddMaps(GetMapperAssemblies));
            var mapper = new Mapper(mapperConfiguration);
            services.AddSingleton<IMapper>(mapper);
        }

        public static IEnumerable<Assembly> GetMapperAssemblies
            => AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
                assembly.FullName.StartsWith("Client"));
    }
}