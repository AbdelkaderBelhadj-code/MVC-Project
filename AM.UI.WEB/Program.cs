using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

// Adds  Controllers With Views
builder.Services.AddControllersWithViews();

//Adds basic MVC functionality
builder.Services.AddMvc();
builder.Services.AddDbContext<DbContext, AMContext>(options =>
       options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Injection de dépendance
builder.Services.AddScoped<IServiceInvite, ServiceInvite>();
builder.Services.AddScoped<IServiceInvitation, ServiceInvitation>();
builder.Services.AddScoped<IServiceSalle, ServiceSalle>();
builder.Services.AddScoped<IServiceFete, ServiceFete>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//Working with Static Files
app.UseStaticFiles();

// Matches request to an endpoint.
app.UseRouting();

// Use the default authorization.
app.UseAuthorization();

// create default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Invite}/{action=Index}/{id?}");

app.Run();
