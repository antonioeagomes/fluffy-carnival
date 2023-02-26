using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fluffy_carnival.Services;
using fluffy_carnival.Services.Interfaces;
using StackExchange.Redis;

namespace fluffy_carnival.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        var multiplexer = ConnectionMultiplexer.Connect("localhost:6379");
        services.AddSingleton<IConnectionMultiplexer>(multiplexer);

        services.AddHttpClient();

        services.AddTransient<IPokemonService, PokemonService>();
        services.AddTransient<IRedisService, RedisService>();

        return services;
    }

}