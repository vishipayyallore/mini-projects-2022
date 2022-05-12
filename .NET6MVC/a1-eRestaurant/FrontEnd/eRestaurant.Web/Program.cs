using eRestaurant.Web.Common;
using eRestaurant.Web.Services;
using eRestaurant.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Base Urls
Constants.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];

// Application Dependencies
builder.Services.AddHttpClient<IProductsService, ProductService>();

// Services
builder.Services.AddScoped<IProductsService, ProductService>();

builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
