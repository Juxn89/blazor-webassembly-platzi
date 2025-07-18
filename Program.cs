using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using blazor_webassembly_platzi;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var platziFakeStoreAPI = builder.Configuration.GetValue<string>("APIs:PlatziFakeStore:baseUrl");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(platziFakeStoreAPI) });
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
