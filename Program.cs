using System;

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

await app.RunAsync();
