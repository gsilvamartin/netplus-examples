using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Entity;

namespace NetPlus.Examples.MongoDB.Entities;

/// <summary>
/// An example class using the BaseEntity class, as you can see, it's very simple to use.
///
/// The BaseEntity class provides the Id property, which is used to identify the document in the database.
/// To use the BaseEntity class, you need to specify the collection name using the [BsonCollection] attribute.
/// </summary>
[BsonCollection("products")]
public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
}