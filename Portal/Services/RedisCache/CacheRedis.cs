using StackExchange.Redis;
using System;

namespace Portal
{
    public class CacheRedis : ICacheRedis
    {
        private static IDatabase redis;

        public T Get<T>(string key)
        {
            redis = Connection.GetDatabase();
            var obj = redis.Get<T>(key);
            if (obj == null)
            {
                return default(T);
            }

            return obj;
        }

        public void Set<T>(string key, T value)
        {
            redis = Connection.GetDatabase();
            if (value != null)
                redis.Set(key, value);
        }

        public void InvalidateCache(string key)
        {
            IDatabase cache = Connection.GetDatabase();
            cache.KeyDelete(key);
        }

        private static Lazy<ConnectionMultiplexer>
        lazyConnection = new Lazy<ConnectionMultiplexer>
        (() =>
        {
            return ConnectionMultiplexer.Connect(
            "localhost:6379,abortConnect=False");
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
