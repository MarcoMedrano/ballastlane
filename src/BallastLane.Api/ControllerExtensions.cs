using BallastLane.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api;

public static class ControllerExtensions
{
    public static void ThrowIfNotAuthorized(this ControllerBase controller, string key, string message = "You are not allowed to modify another user data.")
    {
        if (!key.Equals(SiweJwtMiddleware.GetAddressFromContext(controller.HttpContext), StringComparison.OrdinalIgnoreCase))
             throw new (message);
    }
}