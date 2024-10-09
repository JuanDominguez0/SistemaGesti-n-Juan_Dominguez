using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class UsuarioDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public UsuarioDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public Usuario ObtenerUsuario(int id)
    {
        return _context.Usuarios.FirstOrDefault(p => p.Id == id);
    }

    public List<Usuario> ListarUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario CrearUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public void ModificarUsuario(Usuario usuario)
    {
        var usuarioExistente = ObtenerUsuario(usuario.Id);
        if (usuarioExistente != null)
        {
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Apellido = usuario.Apellido;
            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Contraseña = usuario.Contraseña;
            usuarioExistente.Mail = usuario.Mail;

            _context.SaveChanges();
        }
    }

    public void EliminarUsuario(int id)
    {
        var usuarioEliminar = ObtenerUsuario(id);
        if (usuarioEliminar != null)
        {
            _context.Usuarios.Remove(usuarioEliminar);
            _context.SaveChanges();
        }
    }

    public List<Usuario> Filtrar(string filtro)
    {
        return _context.Usuarios.Where(p => p.Nombre.Contains(filtro) || p.Mail.Contains(filtro) || p.Apellido.Contains(filtro) || p.NombreUsuario.Contains(filtro)).ToList();
    }
}
