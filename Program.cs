using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ilies_Dragos_Restaurant.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Restaurants");
    options.Conventions.AllowAnonymousToPage("/Restaurants/Index");
    options.Conventions.AllowAnonymousToPage("/Restaurants/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/MenuItems", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Menus", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/RestaurantCategories", "AdminPolicy");
});
builder.Services.AddDbContext<Ilies_Dragos_RestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ilies_Dragos_RestaurantContext") ?? throw new InvalidOperationException("Connection string 'Ilies_Dragos_RestaurantContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ilies_Dragos_RestaurantContext") ?? throw new InvalidOperationException("Connection string 'Ilies_Dragos_RestaurantContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
