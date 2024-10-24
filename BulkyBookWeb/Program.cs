using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container e.g. register an email or DB context.
// The below service is used to create the MVC object. Razor pages would be different.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"))); // this method will only look in the json item called "ConnectionStrings"
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline - Determines how an app should respond to a web request
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// These are all types of middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication(); // should be used here to check if user is legit - order matters
app.UseAuthorization(); // can only authorise an authentic user

app.MapControllerRoute( // this is only used if there is no controller or action in the proper route
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // controller and action are not optional with default values; only id is optional

app.Run();
