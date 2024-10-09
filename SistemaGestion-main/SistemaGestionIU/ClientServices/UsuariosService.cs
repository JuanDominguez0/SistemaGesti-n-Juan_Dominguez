using SistemaGestionEntidades.Entidades;
using System.Net.Http.Json;
using Microsoft.AspNetCore.WebUtilities;


namespace SistemaGestionIU.ClientServices;

public class UsuariosService
{
    private readonly HttpClient _httpClient;

    public UsuariosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>?> ListarUsuarios()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("");
    }

    public async Task<Usuario?> ObtenerUsuario(int id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>($"{id}");
    }

    public async Task CrearUsuario(Usuario usuario)
    {
        await _httpClient.PostAsJsonAsync("", usuario);
    }

    public async Task ModificarUsuario(int id, Usuario usuario)
    {
        await _httpClient.PutAsJsonAsync($"{id}", usuario);
    }

    public async Task EliminarUsuario(int id)
    {
        await _httpClient.DeleteAsync($"{id}");
    }

    public async Task<List<Usuario>?> Filtrar(string filtro)
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>(
            QueryHelpers.AddQueryString("", new Dictionary<string, string>() { { "filtro", filtro } }));
    }
}
