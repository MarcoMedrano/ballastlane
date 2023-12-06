using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;

// services.AddScoped<Microsoft.AspNetCore.Components.NavigationManager>();
services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
services.AddAuthServices();
services.AddMudServices();

await builder.Build().RunAsync();
