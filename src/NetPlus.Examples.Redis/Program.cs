using NetPlus.Examples.Redis;
using NetPlus.Examples.Redis.Entities;
using NetPlus.ServiceAbstractions.Cache.Redis.Extensions;

var builder = Host.CreateApplicationBuilder(args);

// Here we configure the instance of Redis
// Using this configuration, we can use the IRedisRepository<T> to interact with the database
builder.Services.ConfigureRedis(config => { config.ConnectionString = "localhost:6379"; });
builder.Services.AddRedisRepository<Product>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();