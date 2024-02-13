using ComicManager.UI.Common.Service;
using ComicManager.UI.Common.Service.Contract;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

// Custom Service implementation
builder.Services.AddSingleton<ICharacterService, CharacterService>();
builder.Services.AddSingleton<IMessageService, MessageService>();

await builder.Build().RunAsync();
