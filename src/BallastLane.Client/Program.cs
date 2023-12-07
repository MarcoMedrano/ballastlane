using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var services = builder.Services;

// services.AddScoped<Microsoft.AspNetCore.Components.NavigationManager>();
services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
services.AddMudServices();
services.AddAuthServices();

await builder.Build().RunAsync();
