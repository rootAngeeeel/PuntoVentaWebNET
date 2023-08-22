using Datos.bdContext.Repositorio;
using Microsoft.EntityFrameworkCore;
using Negocio.Service;
using PV.Datos.bdContext;
using PV.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PvefContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("keyDB"));
});

/* Inyeccion de dependencias */
builder.Services.AddScoped<IGenericRepository<DetalleVentum>, DetalleVentaRepository>();
builder.Services.AddScoped<IDetalleVentaService, DetalleVentaService>();

builder.Services.AddScoped<IGenericRepository<Ventum>, VentaRepository>();
builder.Services.AddScoped<IVentaService, VentaServicie>();

builder.Services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "producto",
        pattern: "Producto/ProductoVista/{id}" );

app.UseDeveloperExceptionPage();

app.Run();
