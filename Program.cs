using EstateHub.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o => { o.LoginPath="/Account/Login"; o.AccessDeniedPath="/Account/Login"; o.ExpireTimeSpan=TimeSpan.FromHours(8); });
builder.Services.AddAuthorization();
builder.Services.AddSingleton<Db>();
var app=builder.Build();
app.UseStaticFiles();app.UseRouting();app.UseAuthentication();app.UseAuthorization();
app.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");
try { using var scope=app.Services.CreateScope();scope.ServiceProvider.GetRequiredService<Db>().Initialize(); }
catch(Exception ex) { Console.Error.WriteLine("DATABASE SETUP ERROR: "+ex.Message);Console.Error.WriteLine("Start MySQL in XAMPP and verify appsettings.json. See README.md.");return; }
app.Run();
