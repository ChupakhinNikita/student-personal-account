using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using webUniversity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Подключение к БД
string connection = "Host=localhost;Port=5432;Database=University2;userName=postgres;Password=123456";
builder.Services.AddDbContext<UniversityContext>(options => options.UseNpgsql(connection));

// Подключение аутентификации с помощью куки
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/login";
        options.AccessDeniedPath = "/Account/login";
    });

// Подключение авторизации
builder.Services.AddAuthorization(opts => {

    opts.AddPolicy("OnlyForAdmin", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Администратор");
    });
    opts.AddPolicy("OnlyForTeacher", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Преподователь");
    });
    opts.AddPolicy("OnlyForStudent", policy => {
        policy.RequireClaim(ClaimTypes.Role, "Студент");
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // Добавление middleware аутентификации 
app.UseAuthorization();   // Добавление middleware авторизации 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
