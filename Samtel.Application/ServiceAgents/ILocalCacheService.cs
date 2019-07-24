using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samtel.Application.ServiceAgents
{
    public interface ILocalCacheService
    {
        bool Add<T>(string key, T obj);
        bool Add<T>(string key, T obj, DateTimeOffset expiresAt);
        T Get<T>(string key);
        IEnumerable<string> Clean();
        bool Remove(string key);
        bool Exists(string key);
    }
}
