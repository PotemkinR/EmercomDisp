using System;

namespace EmercomDisp.BLL.Services
{
    public interface ICacheService
    {
        T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<T> settingFunction);
        void RemoveFromCache(string cacheItemName);
    }
}