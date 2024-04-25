using GestionTurnos.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//conexión a la Db
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(25);
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});
/*
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
    {
        //1.Formulario de logeo
        options.LoginPath = "/Asesores/Login";
        //2. Cuanto tiempo va a estar vivo el cookie
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        //3. Formulario de acceso denegado 
        options.AccessDeniedPath = "/Home/Privacy";
    });

//Cache

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => 
    {
        options.IdleTimeout = TimeSpan.FromSeconds(10);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });
    */



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

app.UseRouting();

/*app.UseAuthentication();*/
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Asesores}/{action=Login}/{id?}");

app.Run();