using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using webClientEx2.Data;
using webClientEx2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<webClientEx2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webClientEx2Context") ?? throw new InvalidOperationException("Connection string 'webClientEx2Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRateService, RateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rates1}/{action=Search}/{id?}");

app.Run();
