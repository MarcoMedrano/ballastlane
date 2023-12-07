using BallastLane.Api.Authorization;
using BallestLane.Dal;
using BallestLane.Dtos.Auth;
using BallestLane.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Siwe;
using Nethereum.Siwe.Core;
using Nethereum.Util;

namespace BallastLane.Api;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(SiweMessageService siweMessageService,
        ISiweJwtAuthorizationService siweJwtAuthService, IUserRepository db)
    : Controller
{
    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest authenticateRequest)
    {
        var siweMessage = SiweMessageParser.Parse(authenticateRequest.SiweEncodedMessage);
        var signature = authenticateRequest.Signature;
        var validUser = await siweMessageService.IsUserAddressRegistered(siweMessage);

        if (!validUser)
        {
            ModelState.AddModelError("Unauthorized", "Invalid User");
            return Unauthorized(ModelState);
        }

        if (!await siweMessageService.IsMessageSignatureValid(siweMessage, signature))
        {
            ModelState.AddModelError("Unauthorized", "Invalid Signature");
            return Unauthorized(ModelState);
        }

        if (siweMessageService.IsMessageTheSameAsSessionStored(siweMessage))
        {
            if (siweMessageService.HasMessageDateStartedAndNotExpired(siweMessage))
            {
                var token = siweJwtAuthService.GenerateToken(siweMessage, signature);
                return Ok(new AuthenticateResponse
                {
                    Address = siweMessage.Address,
                    Jwt = token
                });
            }
            ModelState.AddModelError("Unauthorized", "Expired token");
            return Unauthorized(ModelState);
        }
        ModelState.AddModelError("Unauthorized", "Matching Siwe message with nonce not found");
        return Unauthorized(ModelState);
    }

    [AllowAnonymous]
    [HttpPost("newsiwemessage")]
    public IActionResult GenerateNewSiweMessage(SiweMessageSeed msg)
    {
        SiweMessage message = new DevSiweMessage();
        message.Address = msg.Address.ToLower().ConvertToEthereumChecksumAddress();
        message.ChainId = msg.ChainId.ToString();
        message.Uri = msg.Uri;

        return Ok(siweMessageService.BuildMessageToSign(message));
    }

    [HttpPost("logout")]
    public IActionResult LogOut()
    {
        var siweMessage = SiweJwtMiddleware.GetSiweMessageFromContext(HttpContext);
        siweMessageService.InvalidateSession(siweMessage);
        return Ok();
    }

    [HttpGet("getuser")]
    public async Task<IActionResult> GetAuthenticatedUser()
    {
        //ethereum address
        var address = SiweJwtMiddleware.GetAddressFromContext(HttpContext);
        if (address == null) return Forbid();

        var user = await db.GetById(address.ToLower());

        if (user == null) return NotFound("User is not registered");
        return Ok(user.Adapt<UserDto>());
    }
}