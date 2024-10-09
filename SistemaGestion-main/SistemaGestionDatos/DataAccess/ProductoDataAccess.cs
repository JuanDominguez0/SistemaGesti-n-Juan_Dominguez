using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class ProductoDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public ProductoDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public Producto? ObtenerProducto(int id)
    {
        return _context.Productos.FirstOrDefault(p => p.Id == id);
    }

    public List<Producto> ListarProductos()
    {
        return _context.Productos.ToList();
    }

    public Producto CrearProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        _context.SaveChanges();
        return producto;
    }

    public void ModificarProducto(Producto producto)
    {
        var productoExistente = ObtenerProducto(producto.Id);
        if (productoExistente != null)
        {
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.PrecioVenta = producto.PrecioVenta;
            productoExistente.Costo = producto.Costo;
            productoExistente.Stock = producto.Stock;
            productoExistente.IdUsuario = producto.IdUsuario;

            _context.SaveChanges();
        }
    }

    public void EliminarProducto(int id)
    {
        var productoEliminar = ObtenerProducto(id);
        if (productoEliminar != null)
        {
            _context.Productos.Remove(productoEliminar);
            _context.SaveChanges();
        }
    }

    public List<Producto> Filtrar(string filtro)
    {
        return _context.Productos.Where(p => p.Descripcion.Contains(filtro)).ToList();
    }
}
