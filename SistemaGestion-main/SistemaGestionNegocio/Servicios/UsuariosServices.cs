using SistemaGestionDatos.DataAccess;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionNegocio.Servicios; 

public class UsuariosServices 
{
    private UsuarioDataAccess _usuarioDataAccess;

    public UsuariosServices(UsuarioDataAccess usuarioDataAccess)
    {
        _usuarioDataAccess = usuarioDataAccess;
    }

    public Usuario ObtenerUsuario(int id)
    {
        Usuario usuario = _usuarioDataAccess.ObtenerUsuario(id);
        if (usuario == null) throw new Exception("El usuario solicitado no existe");
        return usuario;
    }

    public List<Usuario> ListarUsuarios()
    {
        return _usuarioDataAccess.ListarUsuarios().ToList();
    }

    public Usuario CrearUsuario(Usuario usuario)
    {
        try
        {
            _usuarioDataAccess.CrearUsuario(usuario);
            return usuario;
        }
        catch (Exception e)
        {
            throw new Exception($"Error en la creacion de usuario {e.Message}");
        }
    }

    public void ModificarUsuario(Usuario usuario)
    {
        try
        {
            _usuarioDataAccess.ModificarUsuario(usuario);
        }
        catch (Exception e)
        {
            throw new Exception($"Error en la actualización del usuario {e.Message}");
        }
    }

    public void EliminarUsuario(int id)
    {
        try
        {
            _usuarioDataAccess.EliminarUsuario(id);
        }
        catch (Exception e)
        {
            throw new Exception("Error al eliminar usuario");
        }
    }

    public List<Usuario> Filtrar(string filtro)
    {
        return _usuarioDataAccess.Filtrar(filtro);  
    }
}