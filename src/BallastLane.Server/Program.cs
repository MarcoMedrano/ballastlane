using BallastLane.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(WeatherForecastController).Assembly));;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//     endpoints.MapBlazorHub();
//     endpoints.MapFallbackToFile("index.html");
// });

app.Run();
