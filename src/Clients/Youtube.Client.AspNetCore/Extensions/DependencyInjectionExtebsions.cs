using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Client.Clients;
using YoutubeApi.Client.Interfaces;
using YoutubeApi.Client.Models;

namespace Youtube.Client.AspNetCore.Extensions
{
    public static class DependencyInjectionExtebsions
    {
        public static IServiceCollection AddYoutubeClient(this IServiceCollection services,YoutubeClientOptions options)
        {
            YoutubeClientOptions youtubeClientOptions = new YoutubeClientOptions();
            services.AddScoped<IYoutubeClient, YoutubeClient>();
            services.AddHttpClient<IYoutubeClient, YoutubeClient>((sp, client)=>
                {
                client.BaseAddress = new Uri(options.HostUri);
            });
            return services;
        }
    }
}
