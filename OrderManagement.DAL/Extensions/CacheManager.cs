using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DAL.Extensions
{

    /// <summary>
    /// Represents a manager for caching during an HTTP request (short term caching)
    /// </summary>
    public partial class CacheManager : ICacheManager
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            throw new NotImplementedException();
        }

        public bool IsSet(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, int cacheTime)
        {
            throw new NotImplementedException();
        }
    }
}
