using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyApp.Client;
using ServiceStack.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

var baseUrl = "https://blazor-wasm.web-templates.io";

// Use / for local or CDN resources
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? builder.HostEnvironment.BaseAddress;
builder.Services.AddBlazorApiClient(baseUrl);
builder.Services.AddLocalStorage();

await builder.Build().RunAsync();
