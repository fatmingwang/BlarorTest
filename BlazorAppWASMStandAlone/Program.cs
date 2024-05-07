using BlazorAppWASMStandAlone;
using BlazorAppWASMStandAlone.CommonFunction;
using BlazorSpinner;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SpinnerService>();
builder.Services.AddScoped<MyCommonFunction>();

builder.Services.AddHttpClient();

await builder.Build().RunAsync();
