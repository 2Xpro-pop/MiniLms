using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MiniLms;
using MiniLms.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();

builder.Services.AddSingleton<IUserService, FakerUserService>();
builder.Services.AddSingleton<ICategoryService, FakerCategoryService>();
builder.Services.AddSingleton<ILessonsService, FakerLessonService>();

await builder.Build().RunAsync();
