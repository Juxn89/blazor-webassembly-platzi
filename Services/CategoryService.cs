using System.Net.Http.Json;
using System.Text.Json;
using blazor_webassembly_platzi.Models;

namespace blazor_webassembly_platzi.Services;

public interface ICategoryService
{
	public Task<List<Category>?> Get();
}

public class CategoryService : ICategoryService
{
	private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _jsonSerializer;

	public CategoryService(HttpClient httpClient)
	{
		_httpClient = httpClient;
		_jsonSerializer = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
	}

	public async Task<List<Category>?> Get()
	{
		var categoriesReponse = await _httpClient.GetAsync("categories");
		var jsonCategories = await categoriesReponse.Content.ReadAsStringAsync();

		if (!categoriesReponse.IsSuccessStatusCode)
			throw new ApplicationException(jsonCategories);

		return JsonSerializer.Deserialize<List<Category>>(jsonCategories);
	}
}