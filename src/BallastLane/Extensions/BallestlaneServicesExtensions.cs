using BallastLane.Api.Authorization;
using BallastLane.Client;
using BallestLane.Business;
using BallestLane.Dal;
using Nethereum.Siwe;

namespace BallastLane.Extensions;

public static class BallestlaneServicesExtensions
{
    public static IServiceCollection AddBallestlaneServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INftRepository, NftRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INftService, NftService>();


        // Authorization
        services.AddSingleton<ISessionStorage, InMemorySessionNonceStorage>();
        services.AddScoped<SiweMessageService>();
        services.AddScoped<ISiweJwtAuthorizationService, SiweJwtAuthorizationService>();

        return services;
    }
}