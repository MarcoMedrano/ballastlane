using System.Net.Http.Json;
using BallestLane.Dtos.Auth;
using Nethereum.Siwe.Core;

namespace BallastLane.Client.Infraestructure;

public class SiweApiUserLoginService
{
    private readonly HttpClient _httpClient;

    public SiweApiUserLoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateNewSiweMessage(string address, ulong chainId)
    {
        var message = new SiweMessageSeed { Address = address, ChainId = chainId };
        var response = await _httpClient.PostAsJsonAsync("authentication/newsiwemessage", message);

        return await response.Content.ReadAsStringAsync();
    }


    public async Task<AuthenticateResponse> Authenticate(SiweMessage siweMessage, string signature)
    {
        var siweMessageEncoded = SiweMessageStringBuilder.BuildMessage(siweMessage);
        var request = new AuthenticateRequest()
        {
            SiweEncodedMessage = siweMessageEncoded,
            Signature = signature
        };

        var response = await _httpClient.PostAsJsonAsync("authentication/authenticate", request);

        return await response.Content.ReadFromJsonAsync<AuthenticateResponse>();
    }

    public async Task<UserDto> GetUser(string token)
    {
        try
        {
            var user = await _httpClient.GetAsync<UserDto>("authentication/getuser", token);
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType());
            return null;
        }
    }

    public async Task Logout(string token)
    {
        try
        {
            await _httpClient.PostAsync("authentication/logout", null, token);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType());
            throw;
        }
    }

}