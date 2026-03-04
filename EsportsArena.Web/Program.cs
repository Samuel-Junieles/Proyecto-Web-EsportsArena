using EsportsArena.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

//Prueba de que XAMPP y MySQL estén conectados correctamente al proyecto.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<EsportsArena.Data.AppDbContext>();
        // Esta línea intenta abrir la conexión con XAMPP
        if (context.Database.CanConnect())
        {
            Console.WriteLine("ÉXITO: El proyecto está conectado a MySQL en XAMPP.");
        }
        else
        {
            Console.WriteLine("ERROR: No se pudo conectar. Revisa que MySQL en XAMPP esté encendido.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR CRÍTICO: {ex.Message}");
    }
}

app.Run();
