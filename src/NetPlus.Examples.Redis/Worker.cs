using NetPlus.Examples.Redis.Entities;
using NetPlus.ServiceAbstractions.Cache.Redis.Interfaces;
using Newtonsoft.Json;

namespace NetPlus.Examples.Redis;

/// <summary>
/// This class is an example of a background service that uses the IRedisRepository{T} to interact with the database.
///
/// The IRedisRepository{T} is a generic interface that provides methods to interact with the Redis database.
/// </summary>
public class Worker : BackgroundService
{
    private readonly IRedisRepository<Product> _productRepository;
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger, IRedisRepository<Product> productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Test Method: Add random product
            var randomProduct = GenerateRandomProduct();
            await _productRepository.SetAsync($"product:{randomProduct.Id}", randomProduct);
            _logger.LogInformation($"Added product with ID: {randomProduct.Id}");

            // Test Method: Get random product
            var randomProductId = GetRandomProductId();
            var retrievedProduct = await _productRepository.GetAsync($"product:{randomProductId}");
            _logger.LogInformation($"Retrieved product: {JsonConvert.SerializeObject(retrievedProduct)}");

            // Test Method: Remove random product
            var productToRemoveId = GetRandomProductId();
            await _productRepository.RemoveAsync($"product:{productToRemoveId}");
            _logger.LogInformation($"Removed product with ID: {productToRemoveId}");

            // Test Method: Get all products
            var allProducts = await _productRepository.GetAllAsync();
            _logger.LogInformation(allProducts.Any()
                ? $"All products: {JsonConvert.SerializeObject(allProducts)}"
                : "No products found.");

            // Test Method: Set all products
            var productDictionary = new Dictionary<string, Product>
            {
                { "product1", new Product { Id = "product1", Name = "TestProduct1", Price = 10.99m } },
                { "product2", new Product { Id = "product2", Name = "TestProduct2", Price = 20.99m } }
            };
            await _productRepository.SetAllAsync(productDictionary);
            _logger.LogInformation("Set all test products.");

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    private Product GenerateRandomProduct()
    {
        var random = new Random();
        return new Product
        {
            Id = Guid.NewGuid().ToString(),
            Name = $"Product-{random.Next(1, 100)}",
            Price = (decimal)random.NextDouble() * 100,
            Category = $"Category-{random.Next(1, 5)}",
            Description = $"Description-{random.Next(1, 10)}",
            Sku = $"SKU-{random.Next(1000, 9999)}"
        };
    }

    private string GetRandomProductId()
    {
        var random = new Random();
        return $"Product-{random.Next(1, 100)}";
    }
}