using Tej_WebApp_Core.Interfaces;
using Tej_WebApp_Core.Models.DbConnection;
using Tej_WebApp_Core.Repositories.Delivered;
using Tej_WebApp_Core.Repositories.DlvTaskList;
using Tej_WebApp_Core.Repositories.Login;
using Tej_WebApp_Core.Repositories.UnDelivered;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILogin,LoginRepository>();
builder.Services.AddScoped<IDlvTaskList,DlvTaskListRepository>();
builder.Services.AddScoped<IDelivered, DeliveredRepository>();
builder.Services.AddScoped<IUnDelivered, UnDeliveredRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var conn = builder.Configuration.GetConnectionString("DbConn");
ShareConection.ConValue = conn;

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
