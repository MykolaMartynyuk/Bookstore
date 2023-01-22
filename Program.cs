using Bookstore.Data;
using Bookstore.Data.DataObjects;
using Bookstore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//autorisation

builder.Services.AddDefaultIdentity<CustomUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//session
//builder.Services.AddSession();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(5);
});

builder.Services.AddScoped<IFileUploadService, FileUploadService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<>

//policies
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminOnly", policyBuilde => policyBuilde.RequireClaim("IsAdmin"));
});



var app = builder.Build();

//add Admin
using (var scope = app.Services.CreateScope())
{
	var userManager = scope.ServiceProvider.GetService<UserManager<CustomUser>>();

	if(userManager.FindByEmailAsync("admin@test.com").Result == null)
	{
		CustomUser adminUser = new CustomUser();
		adminUser.UserName = "admin@test.com";
		adminUser.Email = "admin@test.com";
		adminUser.FirstName = "admin";
		adminUser.LastName = "admin";
		adminUser.BirthDate = DateTime.Now;
		adminUser.EmailConfirmed = true;

		var result = userManager.CreateAsync(adminUser, "Admin123!").Result;

		if (result.Succeeded)
		{
			//Claim[] claims = new Claim[] { new Claim("AdminOnly", "IsAdmin") };
			Claim claim = new Claim("IsAdmin", string.Empty);
			userManager.AddClaimAsync(adminUser, claim).Wait();
		}

	}
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
