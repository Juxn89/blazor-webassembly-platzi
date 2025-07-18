using System.Net.Http.Json;
using System.Text.Json;
using blazor_webassembly_platzi.Models;

namespace blazor_webassembly_platzi.Services;

public interface IProductService
{
	public Task<List<Product>?> Get();
	public Task Add(Product product);
	public Task Delete(int productId);
}

public class ProductService : IProductService
{
	private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _jsonSerializer;

	public ProductService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_jsonSerializer = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
	}

	public async Task<List<Product>?> Get()
	{
		var products = await _httpClient.GetAsync("products");
		var jsonProducts = await products.Content.ReadAsStringAsync();

		if (!products.IsSuccessStatusCode)
			throw new ApplicationException(jsonProducts);

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