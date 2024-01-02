using Application.InterFace;
using Application.Services.Product.Command.AddAttripute;
using Application.Services.Product.Command.AddProduct;
using Application.Services.Product.Command.RemoveProduct;
using Application.Services.Product.Querise.IGetAllProductForAdminService;
using Application.Services.Product.Querise.IGetAttriputeForAdminService;
using Application.Services.Product.Querise.IGetProductForIndexService;
using Application.Services.Slider;
using Application.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region IoC

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IAddProductService, AddProductService>();
builder.Services.AddScoped<IAddAttriputeService, AddAttriputeService>();
builder.Services.AddScoped<IGetAttriputeForAdminService, GetAttriputeForAdminService>();
builder.Services.AddScoped<IGetAllProductForAdminService, GetAllProductForAdminService>();
builder.Services.AddScoped<IRemoveProductService, RemoveProductService>();
builder.Services.AddScoped<ISliderServices, SliderServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IGetProductForIndexService, GetProductForIndexService>();

#endregion

#region Context
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});
#endregion

#region Authentications
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(cOption =>
{
    cOption.LoginPath = "/Authentication/Signin";
    cOption.ExpireTimeSpan = TimeSpan.FromDays(10);
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Error404";
        await next();

    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
