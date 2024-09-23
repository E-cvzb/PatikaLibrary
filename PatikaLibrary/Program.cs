using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");//Giri� yap�ld���nda hangi sayfaya g�nderisin
    options.AccessDeniedPath = new PathString("/");//Ba�lant� koptu�unda nereye g�ndersin
    options.LogoutPath = new PathString("/");//��k�� yapt���nda nereye  g�ndersin
    
});

var app = builder.Build();

app.UseAuthentication();

app.UseFileServer();

app.MapControllerRoute(
    name:"Default",
    pattern:"{controller=Home}/{action=Index}/{id?}");
app.Run();
