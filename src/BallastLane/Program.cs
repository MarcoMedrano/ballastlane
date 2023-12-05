using BallastLane.Client.Pages;
using BallastLane.Components;
using BallastLane.Controllers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.TryAddScoped<IWebAssemblyHostEnvironment, ServerHostEnvironment>();
services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(sp.GetService<IWebAssemblyHostEnvironment>().BaseAddress) });

// Add services to the container.
services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(WeatherForecastController).Assembly));;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);
app.MapControllers();

app.Run();
