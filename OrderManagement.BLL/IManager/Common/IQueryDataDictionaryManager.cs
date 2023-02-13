using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.BLL.IManager.Common
{
    public interface IQueryDataDictionaryManager
    {
        Task<T> GetQueryDataDictionaryAsync<T>(string formKey);
        Task<int> SetQueryDataDictionaryAsync(string formKey, object model = default);
        Task<int> SetQueryDataDictionaryByUrlAsync(string formKey, object model = default);
        string EncQueryDataDictionary(object model);
        T DecQueryDataDictionary<T>(string data);
    }
}
