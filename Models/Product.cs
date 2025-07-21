namespace blazor_webassembly_platzi.Models;

public class Product
{
	public int id { get; set; }
	public string title { get; set; }
	public string slug { get; set; }
	public int price { get; set; }
	public string description { get; set; }
	public Category category { get; set; }
	public List<string> images { get; set; }
	public string image { get; set; }
	public string categoryId { get; set; }
}