using NetPlus.Examples.MongoDB;
using NetPlus.Examples.MongoDB.Entities;
using NetPlus.Examples.MongoDB.Services;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Extensions;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Interfaces;

var builder = Host.CreateApplicationBuilder(args);

// Here we configure the instance of MongoDB
// Using this configuration, we can use the IMongoRepository<T> to interact with the database
builder.Services.ConfigureMongoDb(config =>
{
    config.ConnectionString = "mongodb://localhost:27017";
    config.DatabaseName = "netplus";
});

// For using the IMongoRepository<T> we need to register it in the service collection
builder.Services.AddMongoRepository<Product>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();