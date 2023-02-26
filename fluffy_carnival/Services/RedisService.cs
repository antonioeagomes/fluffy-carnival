using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fluffy_carnival.Services.Interfaces;
using StackExchange.Redis;

namespace fluffy_carnival.Services;

public class RedisService : IRedisService
{
    private readonly IConnectionMultiplexer _redis;
    public RedisService(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }
    public async Task Save(string key, string values) {
        var cache = _redis.GetDatabase();
        await cache.StringSetAsync(key, values);
    }

    public async Task<string?> Read(string key) {
        var cache = _redis.GetDatabase();
        return await cache.StringGetAsync(key);
    }

     private async Task DeleteKey(string key) {
        var cache = _redis.GetDatabase();
        await cache.KeyDeleteAsync(key);
    }
}