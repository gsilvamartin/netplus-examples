using NetPlus.Examples.MongoDB.Entities;
using NetPlus.Examples.MongoDB.Services;

namespace NetPlus.Examples.MongoDB;

/// <summary>
/// This is the Worker class, which is a BackgroundService.
///
/// The Worker class is used to demonstrate how to use the MongoDB Service Abstraction.
/// </summary>
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IProductService _productService;

    /// <summary>
    /// Constructor of our MongoDB Sample Worker.
    /// </summary>
    /// <param name="productService">Product Service Received by DI</param>
    /// <param name="logger">Logger instance</param>
    public Worker(IProductService productService, ILogger<Worker> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Running MongoDB Sample Worker");
        _logger.LogInformation("Creating products...");
        await CreateProducts();
        _logger.LogInformation("Getting products...");
        var products = await GetProducts();
        _logger.LogInformation("Products: ");
        foreach (var product in products) _logger.LogInformation($"Products: {product.Name} - {product.Price}");
        _logger.LogInformation("Counting products...");
        var totalProducts = await CountProducts();
        _logger.LogInformation($"Total products: {totalProducts}");
    }

    private async Task CreateProducts()
    {
        var products = new List<Product>
        {
            new Product
            {
                Name = "Product 1",
                Price = 100,
                Category = "Category 1",
                Description = "Description 1",
                Sku = "SKU1"
            },
            new Product
            {
                Name = "Product 2",
                Price = 200,
                Category = "Category 2",
                Description = "Description 2",
                Sku = "SKU2"
            },
            new Product
            {
                Name = "Product 3",
                Price = 300,
                Category = "Category 3",
                Description = "Description 3",
                Sku = "SKU3"
            }
        };

        foreach (var product in products)
        {
            await _productService.CreateProduct(product);
        }
    }

    private async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productService.GetProducts();
    }

    private async Task<long> CountProducts()
    {
        return await _productService.CountProducts();
    }

    private async Task UpdateProduct(string id, Product product)
    {
        await _productService.UpdateProduct(id, product);
    }
}