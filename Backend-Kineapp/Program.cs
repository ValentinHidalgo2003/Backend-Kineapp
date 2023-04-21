using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Net.WebSockets;
using System.Net;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<KineappContext>();  // INYECCION DE DEPENDENCIA  
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// static async Task Echo(WebSocket webSocket)
//{
//    var buffer = new byte[1024 * 4];
//    WebSocketReceiveResult result;
//    do
//    {
//        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
//        await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
//    } while (!result.CloseStatus.HasValue);
//}

//var host = Host.CreateDefaultBuilder(args)
//           .ConfigureWebHostDefaults(webBuilder =>
//           {
//               webBuilder.Configure(app =>
//               {
//                   app.UseWebSockets();
//                   app.Use(async (context, next) =>
//                   {
//                       if (context.WebSockets.IsWebSocketRequest)
//                       {
//                           using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
//                           await Echo(webSocket);
//                           return;
//                       }
//                       await next();
//                   });

//                   app.UseRouting();
//                   app.UseEndpoints(endpoints =>
//                   {
//                       endpoints.MapGet("/", async context =>
//                       {
//                           await context.Response.WriteAsync("Hello World!");
//                       });
//                   });
//               });
//           });

//await host.RunConsoleAsync();


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

app.UseAuthorization();

app.MapControllers();

app.Run();





