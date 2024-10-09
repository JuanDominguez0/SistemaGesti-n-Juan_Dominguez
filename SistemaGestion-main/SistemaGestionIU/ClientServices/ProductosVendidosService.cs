using SistemaGestionEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionIU.ClientServices;

public class ProductosVendidosService
{
    private readonly HttpClient _httpClient;

    public ProductosVendidosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductoVendido>?> ListarProductosVendidos()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductoVendido>>("");
    }

    public async Task<ProductoVendido?> ObtenerProductoVendido(int id)
    {
        return await _httpClient.GetFromJsonAsync<ProductoVendido>($"{id}");
    }

    public async Task CrearProductoVendido(ProductoVendido producto)
    {
        await _httpClient.PostAsJsonAsync("", producto);
    }

    public async Task ModificarProductoVendido(int id, ProductoVendido producto)
    {
        await _httpClient.PutAsJsonAsync($"{id}", producto);
    }

    public async Task EliminarProductoVendido(int id)
    {
        await _httpClient.DeleteAsync($"{id}");
    }
}
