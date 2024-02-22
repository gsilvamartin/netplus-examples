namespace NetPlus.Examples.Redis.Entities;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
}