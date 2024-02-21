using NetPlus.Examples.MongoDB.Entities;
using NetPlus.Examples.MongoDB.Services;

namespace NetPlus.Examples.MongoDB;

public class Worker : BackgroundService
{
    private readonly IProductService _productService;

    public Worker(ILogger<Worker> logger)
    {
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
    }

    private async Task SeedData()
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
}