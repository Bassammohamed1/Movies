using Microsoft.EntityFrameworkCore;
using Movies.Models;
using Movies.Repository;
using Movies.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Movies.Data.Consts;
using Movies.Data.Cart;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(c=>ShoppingCart.GetShoppingCart(c));
builder.Services.AddSession();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
await Roles.CreateUser(roleManager);
await Roles.CreateAdmin(roleManager);
await Users.CreateUser(userManager);
await Users.CreateAdmin(userManager);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Movies}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.Run();