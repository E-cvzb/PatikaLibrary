using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");//Giriþ yapýldýðýnda hangi sayfaya gönderisin
    options.AccessDeniedPath = new PathString("/");//Baðlantý koptuðunda nereye göndersin
    options.LogoutPath = new PathString("/");//Çýkýþ yaptýðýnda nereye  göndersin
    
});

var app = builder.Build();

app.UseAuthentication();

app.UseFileServer();

app.MapControllerRoute(
    name:"Default",
    pattern:"{controller=Home}/{action=Index}/{id?}");
app.Run();
