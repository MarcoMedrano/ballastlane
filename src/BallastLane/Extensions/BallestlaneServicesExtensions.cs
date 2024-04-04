using BallastLane.Api.Authorization;
using Ballastlane.Domain.Repositories;
using BallestLane.Business;
using BallestLane.Dal;
using Nethereum.Siwe;
using Ballastlane.Domain.Abstractions;

namespace BallastLane.Extensions;

public static class BallestlaneServicesExtensions
{
    public static IServiceCollection AddBallestlaneServices(this IServiceCollection services)
    {
        services.AddScoped<IDbUnitOfWork, DbUnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INftRepository, NftRepository>();

        services.AddScoped<CreateUserHandler, CreateUserHandler>();
        services.AddScoped<UpdateUserHandler, UpdateUserHandler>();
        services.AddScoped<DeleteUserHandler, DeleteUserHandler>();

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