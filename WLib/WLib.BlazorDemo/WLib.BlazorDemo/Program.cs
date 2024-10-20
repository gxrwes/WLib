using WLib.BlazorDemo.Client.Pages;
using WLib.BlazorDemo.Components;
using WLib.Util.Services;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Register ILogger
builder.Services.AddLogging(config =>
{
    config.AddConsole(); // You can add more log providers here as needed
});

// Register all services as scoped
builder.Services.AddScoped<IFileLoaderService, FileLoaderService>();
builder.Services.AddScoped<IMarkdownParser, MarkdownParser>();

// Register platform-specific IFileCopyService (Linux or Windows)
if (OperatingSystem.IsLinux())
{
    builder.Services.AddScoped<IFileCopyService, LinuxCopyService>();
}
else if (OperatingSystem.IsWindows())
{
    builder.Services.AddScoped<IFileCopyService, WinCopyService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WLib.BlazorDemo.Client._Imports).Assembly);

app.Run();
