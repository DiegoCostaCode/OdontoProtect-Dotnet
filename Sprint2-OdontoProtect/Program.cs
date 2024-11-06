using Microsoft.EntityFrameworkCore;
using Sprint2_OdontoProtect.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ModelContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("FiapOracleConnection")));

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

app.MapControllerRoute(
    name: "odontoPacientes",
    pattern: "{controller=OdontoPacientes}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "odontoClinicas",
    pattern: "{controller=OdontoClinicas}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "odontoDoutors",
    pattern: "{controller=OdontoDoutors}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "odontoClinicaDoutors",
    pattern: "{controller=OdontoClinicaDoutors}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "odontoProcedimentos",
    pattern: "{controller=OdontoProcedimentos}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "odontoAtendimentos",
    pattern: "{controller=OdontoAtendimentos}/{action=Index}/{id?}");

app.Run();