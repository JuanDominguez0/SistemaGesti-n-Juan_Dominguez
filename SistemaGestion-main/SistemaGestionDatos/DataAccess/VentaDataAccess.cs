using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class VentaDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public VentaDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public Venta? ObtenerVenta(int id)
    {
        return _context.Ventas.FirstOrDefault(p => p.Id == id);
    }

    public List<Venta> ListarVentas()
    {
        return _context.Ventas.ToList();
    }

    public Venta CrearVenta(Venta venta)
    {
        _context.Ventas.Add(venta);
        _context.SaveChanges();
        return venta;
    }

    public void ModificarVenta(Venta venta)
    {
        var ventaExistente = ObtenerVenta(venta.Id);
        if (ventaExistente != null)
        {
            ventaExistente.Comentario = venta.Comentario;
            ventaExistente.IdUsuario = venta.IdUsuario;

            _context.SaveChanges();
        }
    }

    public void EliminarVenta(int id)
    {
        var ventaEliminar = ObtenerVenta(id);
        if (ventaEliminar != null)
        {
            _context.Ventas.Remove(ventaEliminar);
            _context.SaveChanges();
        }
    }

    public List<Venta> Filtrar(string filtro)
    {
        return _context.Ventas.Where(p => p.Comentario.Contains(filtro)).ToList();
    }
}
