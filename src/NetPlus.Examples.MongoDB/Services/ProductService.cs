using NetPlus.Examples.MongoDB.Entities;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Interfaces;

namespace NetPlus.Examples.MongoDB.Services;

public class ProductService : IProductService
{
    private readonly IMongoRepository<Product> _productRepository;

    public ProductService(IMongoRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task CreateProduct(Product product)
    {
        await _productRepository.InsertAsync(product);
    }

    public async Task UpdateProduct(string id, Product product)
    {
        await _productRepository.UpdateAsync(id, product);
    }

    public async Task DeleteProduct(string id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
    {
        return await _productRepository.FindAsync(x => x.Category == category);
    }

    public async Task<IEnumerable<Product>> GetProductsByPrice(decimal price)
    {
        return await _productRepository.FindAsync(x => x.Price == price);
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return await _productRepository.FindAsync(x => x.Price >= minPrice && x.Price <= maxPrice);
    }

    public async Task<IEnumerable<Product>> GetProductsBySku(string sku)
    {
        return await _productRepository.FindAsync(x => x.Sku == sku);
    }

    public async Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        return await _productRepository.FindAsync(x => x.Name == name);
    }

    public async Task<IEnumerable<Product>> GetProductsByDescription(string description)
    {
        return await _productRepository.FindAsync(x => x.Description == description);
    }
}