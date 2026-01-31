using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services
//	.AddRefitClient<ITmdbApi>(refitSettings)
//	.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"));

await builder.Build().RunAsync();
