using StackExchange.Redis;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Portal
{
    public static class RedisCacheExtension
    {
        public static T Get<T>(this IDatabase cache, string key)
        {
            return Deserialize<T>(cache.StringGet(key));
        }

        public static void Set(this IDatabase cache, string key, object value)
        {
            if (cache == null)
                throw new Exception();
            else
                cache.StringSet(key, Serialize(value));
        }

        static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream =
                                          new MemoryStream(stream))
            {
                T result =
                      (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}
