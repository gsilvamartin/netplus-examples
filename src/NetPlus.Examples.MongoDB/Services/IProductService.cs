using NetPlus.Examples.MongoDB.Entities;

namespace NetPlus.Examples.MongoDB.Services;

/// <summary>
/// This is the interface that we will use to interact with the Product entity.
///
/// The interface is used to define the methods that we will use to interact with the database.
/// All the database methods are defined here, and the implementation is done in the ProductService class.
///
/// All the methods is using the MongoDb Service Abstraction.
/// </summary>
public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(string id);
    Task CreateProduct(Product product);
    Task UpdateProduct(string id, Product product);
    Task DeleteProduct(string id);
    Task<IEnumerable<Product>> GetProductsByCategory(string category);
    Task<IEnumerable<Product>> GetProductsByPrice(decimal price);
    Task<IEnumerable<Product>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
    Task<IEnumerable<Product>> GetProductsBySku(string sku);
    Task<IEnumerable<Product>> GetProductsByName(string name);
    Task<IEnumerable<Product>> GetProductsByDescription(string description);
    Task<long> CountProducts();
}