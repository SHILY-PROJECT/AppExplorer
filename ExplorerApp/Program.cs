using ExplorerApp.Components;
using ExplorerApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddRazorPages();
services.AddServerSideBlazor();

services.AddSingleton<IAppDataManager, AppDataManager>();
services.AddSingleton<INavigator, Navigator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.MapBlazorHub();

app.Run();