using System.Net.Http.Json;
using System.Text.Json;
using blazor_webassembly_platzi.Models;

namespace blazor_webassembly_platzi.Services;

public class CategoryService
{
	private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _jsonSerializer;

	public CategoryService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
	{
		_httpClient = httpClient;
		_jsonSerializer = jsonSerializerOptions;
	}

	public async Task<List<Category>?> Get()
	{
		var categoriesReponse = await _httpClient.GetAsync("categories");
		var jsonCategories = await categoriesReponse.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<List<Category>>(jsonCategories);
	}
}