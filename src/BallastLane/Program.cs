using BallastLane.Api;
using BallastLane.Api.Authorization;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

services.AddBallestlaneServices();
services.AddAballestlaneDbContext(builder.Configuration);

// Add services to the container.
services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(NftsController).Assembly));;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseBallestlaneDb();
app.UseMiddleware<SiweJwtMiddleware>();
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

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAntiforgery();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
