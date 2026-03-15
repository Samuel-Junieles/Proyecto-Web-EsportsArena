using EsportsArena.Data.Context;
using EsportsArena.Data.DAO;
using EsportsArena.Data.Interface;
using EsportsArena.Logic.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración del GenericDAO
builder.Services.AddScoped(typeof(IGenericDAO<>), typeof(GenericDAO<>));

// Registro de los Servicios de Lógica De Negocio
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EncuentroService>();
builder.Services.AddScoped<EquipoService>();
builder.Services.AddScoped<TorneoService>();

// Habilitar Sesiones para el Login
builder.Services.AddSession();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

//Prueba de que XAMPP y MySQL estén conectados correctamente al proyecto.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<EsportsArena.Data.Context.AppDbContext>();
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
