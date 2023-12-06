using BallestLane.Dtos.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Nethereum.Blazor;
using Nethereum.UI;

namespace BallastLane.Client.Auth;

public partial class Metamask
{
    private bool authorizingInProgress;
    private UserDto User => UserState!.User;
    [CascadingParameter] private UserState? UserState { get; set; }

    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    [Inject] private IEthereumHostProvider EthHostProvider { get; set; } = null!;

    private bool MetamaskAvailable { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender) return;

        MetamaskAvailable = await EthHostProvider.CheckProviderAvailabilityAsync();
        StateHasChanged();
    }

    protected async Task LoginWithMetaMask()
    {
        authorizingInProgress = true;
        try
        {
            User.Id = await EthHostProvider.EnableProviderAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to login " + e.Message);
        }
        finally
        {
            authorizingInProgress = false;
        }

        if (AuthenticationStateProvider is EthereumAuthenticationStateProvider)
            ((EthereumAuthenticationStateProvider)AuthenticationStateProvider)?.NotifyStateHasChanged();

        StateHasChanged();
    }
}