using RedisDemo;
using StackExchange.Redis;
using System.Reflection;

    var connection = new RedisConnection();
    // var database = connection.Connect("localhost:6379");
    var config = ConfigurationOptions.Parse("127.0.0.1:6379");
    var database = connection.Connect(config.ToString());
    database.Set("dto", "123");
