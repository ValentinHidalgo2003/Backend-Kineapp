using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net.WebSockets;
using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<KineappContext>();  // INYECCION DE DEPENDENCIA  
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/api/Login/loguear";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.AccessDeniedPath = "/api/Turno";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Other middleware
    app.UseRouting(); // Add UseRouting middleware
    app.UseEndpoints(endpoints =>
    {
        // Configured endpoints
        endpoints.MapControllers(); // Map API controllers
    });
}
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<StartupBase>();
            webBuilder.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 7167, listenOptions =>
                {
                    listenOptions.UseHttps();
                    listenOptions.KestrelServerOptions.AllowSynchronousIO = true;
                });
                options.Listen(IPAddress.Any, 7166, listenOptions =>
                {
                    listenOptions.UseHttps();
                    listenOptions.KestrelServerOptions.AllowSynchronousIO = true;
                });
            });
            webBuilder.UseUrls("https://*:7167", "http://*:7166");
        });



app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
});


app.UseHttpsRedirection();

app.UseAuthentication();



//app.MapControllerRoute(
//    name: "default",
//    pattern : "{controller=LoginController}/{action=Index}/{id?}");
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "login",
        pattern: "api/Login/loguear",
        defaults: new { controller = "Login", action = "LoginPaciente" });
    // Otras rutas...
});


app.Run();





