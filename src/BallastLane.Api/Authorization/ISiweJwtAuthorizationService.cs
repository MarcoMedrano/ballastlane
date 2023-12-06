using Nethereum.Siwe.Core;

namespace BallastLane.Api.Authorization;

public interface ISiweJwtAuthorizationService
{
    string GenerateToken(SiweMessage user, string signature);
    Task<SiweMessage> ValidateToken(string token);
}