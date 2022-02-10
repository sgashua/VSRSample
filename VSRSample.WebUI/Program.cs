using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using VSRSample.Persistence;
using VSRSample.Persistence.Context;
using VSRSample.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddPersistence(configuration);
builder.Services.AddApplication();
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationExpanders.Add(new FeatureFolderRazorViewEngine());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Areas")),
    RequestPath = "/Areas"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Frontend}/{controller=Home}/{action=Index}/{id?}");

app.Run();
