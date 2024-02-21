using NetPlus.Examples.MongoDB;
using NetPlus.Examples.MongoDB.Services;
using NetPlus.ServiceAbstractions.Database.NoSQL.MongoDB.Extensions;

var builder = Host.CreateApplicationBuilder(args);

// Here we configure the instance of MongoDB
// Using this configuration, we can use the IMongoRepository<T> to interact with the database
builder.Services.ConfigureMongoDb(config =>
{
    config.ConnectionString = "mongodb://localhost:27017";
    config.DatabaseName = "netplus";
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();