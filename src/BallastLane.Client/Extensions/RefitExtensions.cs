using Refit;

namespace BallastLane.Client.Extensions;

public static class RefitExtensions
{
    public static IHttpClientBuilder AddRefit<T>(this IServiceCollection services, string url) where T : class
    {
        return services.AddRefitClient<T>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(url))
            .AddHttpMessageHandler<BearerTokenHandler>();
    }
}