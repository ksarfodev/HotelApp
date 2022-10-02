using HotelApp.BlazorWasm;
using HotelApp.BlazorWasm.Models;
using HotelApp.BlazorWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.IO;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfigurationBuilder, ConfigurationBuilder>();

//Use Azure Function
builder.Services.AddSingleton<IApiService, AzureFunctionsService>();

//builder.Services.AddSingleton<IApiService,ApiService>(); //Uncomment this to use HotelApp.API
builder.Services.AddSingleton<RoomSelection>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
