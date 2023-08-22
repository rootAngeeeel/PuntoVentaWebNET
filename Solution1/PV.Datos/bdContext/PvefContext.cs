using Microsoft.EntityFrameworkCore;
using PV.Modelos;

namespace PV.Datos.bdContext;

public partial class PvefContext : DbContext
{
    public PvefContext()
    {
    }

    public PvefContext(DbContextOptions<PvefContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta);

            entity.ToTable("detalle_venta");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("id_detalle_venta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.PrecioXPieza).HasColumnName("precio_x_pieza");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.id_producto);
            
            entity.ToTable("producto");

            entity.Property(e => e.descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.id_producto)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_producto");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.proveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proveedor");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.ToTable("venta");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
