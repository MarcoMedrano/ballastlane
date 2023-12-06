using BallestLane.Business;
using BallestLane.Dal;

namespace BallastLane.Extensions;

public static class BallestlaneServicesExtensions
{
    public static IServiceCollection AddBallestlaneServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INftService, NftService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INftRepository, NftRepository>();

        return services;
    }
}