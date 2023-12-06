using Microsoft.AspNetCore.Http;
using Nethereum.Siwe.Core;

namespace BallastLane.Api.Authorization;

public class SiweJwtMiddleware(RequestDelegate next)
{
    public const string ContextEthereumAddress = "ethereumAddress";
    public const string ContextSiweMessage = "siweMessage";

    public static string? GetAddressFromContext(HttpContext context)
    {
        if (context.Items.ContainsKey(ContextEthereumAddress)) return (string)context.Items[ContextEthereumAddress]!;

        return null;
    }

    public static SiweMessage? GetSiweMessageFromContext(HttpContext context)
    {
        if (context.Items.ContainsKey(ContextSiweMessage)) return (SiweMessage)context.Items[ContextSiweMessage]!;

        return null;
    }

    public static void SetSiweMessage(HttpContext context, SiweMessage siweMessage)
    {
        context.Items[ContextSiweMessage] = siweMessage;
    }

    public static void SetEthereumAddress(HttpContext context, string address)
    {
        context.Items[ContextEthereumAddress] = address.ToLower();
    }

    public async Task InvokeAsync(HttpContext context, ISiweJwtAuthorizationService siweJwtAuthorization)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var siweMessage = await siweJwtAuthorization.ValidateToken(token);
        if (siweMessage != null)
        {
            SetEthereumAddress(context, siweMessage.Address);
            SetSiweMessage(context, siweMessage);
        }

        await next(context);
    }
}