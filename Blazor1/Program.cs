using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor1;
using Blazor1.Service;
using Blazor1.Service.Login;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<TodoService, ToDoServiceServer>();
builder.Services.AddScoped<ILoginService, LoginServiceClientSide>();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();