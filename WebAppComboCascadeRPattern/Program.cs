using Serilog.Events;
using Serilog;
using CLCommon.Models;
using CLCommon.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();   // NO Microsoft Logging - VEDERE Sezione Logging di appsettings.json

// SERILOG
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build())
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)  // NO Microsoft Logging
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(logger);

// SERILOG

//  placing UseSerilogRequestLogging() after UseStaticFiles



// Add services to the container.
// INSTALLARE RAZOR RUNTIMECOMPILATION
https://www.reddit.com/r/dotnet/comments/14zd7zp/brand_new_default_aspnet_core_mvc_8_project/
// A solution I found was installing the Nuget Package "Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation"
// and then in my Program.cs I appended builder.Services.AddControllersWithViews()

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
// ADD ENTITY FRAMEWORK
builder.Services.AddDbContext<CorsoAcademyContext>(
    );

//builder.Services.AddSingleton<IRepositoryAsync<TRegione>, EntityFrameworkRepositoryAsync<TComune>>();
//builder.Services.AddSingleton<IRepositoryAsync<TProvincia>, EntityFrameworkRepositoryAsync<TComune>>();
builder.Services.AddSingleton<IRepositoryAsync<TComune>, EntityFrameworkRepositoryAsync<TComune>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


//SERILOG
app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
