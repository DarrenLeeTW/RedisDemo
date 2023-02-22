using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    internal class RedisConnection
    {
        private static ConcurrentDictionary<string, Lazy<ConnectionMultiplexer>> s_connectionPool = new();

        public IDatabase Connect(string setting = "localhost")
        {
            var connMultiplexer = s_connectionPool.GetOrAdd(setting,
                new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(setting)));

            return connMultiplexer.Value.GetDatabase();
        }

        public IDatabase GetDatabase(string setting = "localhost")
        {
            if (s_connectionPool.TryGetValue(setting, out var connMultiplexer))
            {
                return connMultiplexer.Value.GetDatabase();
            }

            return default;
        }
    }
}
