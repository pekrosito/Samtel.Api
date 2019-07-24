using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using Samtel.Application.ServiceAgents;

namespace Samtel.Infraestructure.CacheServices
{
    public class LocalCacheService : ILocalCacheService
    {
        public bool Add<T>(string key, T obj)
        {
            HttpRuntime.Cache.Insert(key, obj);
            return true;
        }

        public bool Add<T>(string key, T obj, DateTimeOffset expiresAt)
        {
            HttpRuntime.Cache.Insert(key, obj, null, expiresAt.UtcDateTime, Cache.NoSlidingExpiration);
            return true;
        }

        public T Get<T>(string key)
        {
            try
            {
                return (T)HttpRuntime.Cache.Get(key);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public IEnumerable<string> Clean()
        {
            var keys = new List<string>();
            foreach (DictionaryEntry dEntry in HttpContext.Current.Cache)
            {
                keys.Add(dEntry.Key.ToString());
                HttpContext.Current.Cache.Remove(dEntry.Key.ToString());
            }
            return keys;
        }

        public bool Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
            return true;
        }

        public bool Exists(string key)
        {
            try
            {
                return HttpRuntime.Cache.Get(key) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
