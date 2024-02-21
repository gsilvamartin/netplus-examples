using NetPlus.Examples.MongoDB.Entities;

namespace NetPlus.Examples.MongoDB.Services;

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