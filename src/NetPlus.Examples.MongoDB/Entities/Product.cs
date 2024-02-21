using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Entity;

namespace NetPlus.Examples.MongoDB.Entities;

[BsonCollection("products")]
public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
}