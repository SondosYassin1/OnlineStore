using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{ //It tells EF Core how to connect to the database and which database provider to use.
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Identity Middleware: function use when the server reserved requests
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true; //Arabic,special character
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Account/login";
    options.AccessDeniedPath = "/Account/AcessDenied";
    options.SlidingExpiration = true; // If we put this, we should put the TimeSpan.FromMinutes()
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


using (var scop = app.Services.CreateScope())
{
    var services = scop.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
       var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
       var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // seed roles
        await InitialSetup.SeedRolesAsync(roleManager);

        // seed admin user 
        await InitialSetup.SeedAdminUserAsync(userManager);
    }
    catch(Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occure while seeding the database.");
    }
}

app.Run();
