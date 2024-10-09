using Microsoft.AspNetCore.WebUtilities;
using SistemaGestionEntidades.Entidades;
using System.Net.Http.Json;


namespace SistemaGestionIU.ClientServices;

public class ProductosService
{
    private readonly HttpClient _httpClient;

    public ProductosService(HttpClient httpClient)
    {
        _httpClient = httpClient; 
    }

    public async Task<List<Producto>?> ListarProductos()
    {
        return await _httpClient.GetFromJsonAsync<List<Producto>>("");
    }

    public async Task<Producto?> ObtenerProducto(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"{id}");
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al obtener el producto: {e.Message}");
        }
    }

    public async Task CrearProducto(Producto producto)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("", producto);
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al crear el producto: {e.Message}");
        }
    }

    public async Task ModificarProducto(int id, Producto producto)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"api/Productos/{id}", producto);
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al modificar el producto: {e.Message}");
        }
    }

    public async Task EliminarProducto(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"{id}");
        }
        catch (HttpRequestException e) 
        {
            throw new Exception($"Error al eliminar el producto: {e.Message}");
        }
    }

    public async Task<List<Producto>?> Filtrar(string filtro)
    {
        return await _httpClient.GetFromJsonAsync<List<Producto>>(
            QueryHelpers.AddQueryString("", new Dictionary<string, string>() { { "filtro", filtro } }));
    }
}
