using System;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
await using var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.UseStaticFiles();
//app.MapControllerRoute("Default", "{Controller=Home}/{Action=Index}/{id?}");

//app.MapGet("/", (Func<string>)(() => "Hello World!"));

app.Map("/angularapps/childapp", builder =>
{
    builder.UseSpa(spa =>
    {
        if (app.Environment.IsDevelopment()) {
            spa.UseProxyToSpaDevelopmentServer($"http://localhost:4201/");
        }
        else {
            var staticPath = Path.Combine(
                Directory.GetCurrentDirectory(), $"wwwroot/angularapps/dist/chaildapp");
            var fileOptions = new StaticFileOptions { FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(staticPath) };
            builder.UseSpaStaticFiles(options: fileOptions);
            spa.Options.DefaultPageStaticFileOptions = fileOptions;
        }
    });
});

await app.RunAsync();
