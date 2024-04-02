using BallastLane.Api.Authorization;
using BallastLane.Client;
using Ballastlane.Domain.Repositories;
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

        services.AddScoped<IUserCommands, UserCommands>();
        services.AddScoped<IUserQueries, UserQueries>();
        services.AddScoped<INftService, NftService>();


        // Authorization
        services.AddSingleton<ISessionStorage, InMemorySessionNonceStorage>();
        services.AddScoped<SiweMessageService>();
        services.AddScoped<ISiweJwtAuthorizationService, SiweJwtAuthorizationService>();

        return services;
    }
}