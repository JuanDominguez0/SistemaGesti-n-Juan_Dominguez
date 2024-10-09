using Microsoft.EntityFrameworkCore;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.Contexts;

public class ProyectoCoderhouseDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<ProductoVendido> ProductosVendidos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Ventas { get; set; }

    public ProyectoCoderhouseDbContext(DbContextOptions<ProyectoCoderhouseDbContext> options) : base(options)
    { }

    public ProyectoCoderhouseDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=PCDIF-IT12;Initial Catalog=Coderhouse;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
