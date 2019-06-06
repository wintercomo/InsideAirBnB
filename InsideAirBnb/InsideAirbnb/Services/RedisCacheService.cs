using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsideAirbnb.Services
{
    public class RedisCacheService
    {
        private static ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("InsideAirBnbRedisCache.redis.cache.windows.net:6380,password=3dTD+Nqo67uXnPsoznnU9VcpjhaWhEPvENrGfg97zCc=,ssl=True,abortConnect=False");
        private static IDatabase database = connectionMultiplexer.GetDatabase();

        public static IDatabase GetInstance()
        {
            return database;
        }
    }
}
