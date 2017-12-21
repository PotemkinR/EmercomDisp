using System;
using System.Runtime.Caching;

namespace EmercomDisp.BLL.Services
{
    public class CacheService:ICacheService
    {
        public T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<T> settingFunction)
        {
            var cache = MemoryCache.Default;
            var cachedObject = (T)cache[cacheItemName];
            if (cachedObject == null)
            {
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes)
                };
                cachedObject = settingFunction();
                cache.Set(cacheItemName, cachedObject, policy);
            }
            return cachedObject;
        }

        public void RemoveFromCache(string cacheItemName)
        {
            var cache = MemoryCache.Default;
            if (cache.Contains(cacheItemName))
            {
                cache.Remove(cacheItemName);
            }
        }
    }
}
