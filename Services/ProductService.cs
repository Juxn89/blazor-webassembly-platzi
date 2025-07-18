using System.Net.Http.Json;
using System.Text.Json;
using blazor_webassembly_platzi.Models;

namespace blazor_webassembly_platzi.Services;

public class ProductService
{
	private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _jsonSerializer;

	public ProductService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
	{
		_httpClient = httpClient;
		_jsonSerializer = jsonSerializerOptions;
	}

	public async Task<List<Product>?> Get()
	{
		var products = await _httpClient.GetAsync("products");
		var jsonProducts = await products.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<List<Product>>(jsonProducts);
	}

	public async Task Add(Product product)
	{
		var productResponse = await _httpClient.PostAsync("products", JsonContent.Create(product));
		var productContent = await productResponse.Content.ReadAsStringAsync();

		if (!productResponse.IsSuccessStatusCode)
			throw new ApplicationException(productContent);
	}

	public async Task Delete(int productId)
	{
		var productResponse = await _httpClient.DeleteAsync($"products/{productId}");
		var productContent = await productResponse.Content.ReadAsStringAsync();

		if (!productResponse.IsSuccessStatusCode)
			throw new ApplicationException(productContent);
	}
}