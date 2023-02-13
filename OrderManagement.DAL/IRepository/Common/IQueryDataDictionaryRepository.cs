using OrderManagementViewModel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DAL.IRepository.Common
{
    public interface IQueryDataDictionaryRepository
    {

        Task<QueryDataDictionary> GetQueryDataDictionaryAsync(string formKey, int userId, CancellationToken cancellationToken = default);
        Task<int> InsertQueryDataDictionaryAsync(string formKey, QueryDataDictionary model, CancellationToken cancellationToken = default);
        Task<int> UpdateQueryDataDictionaryAsync(string formKey, QueryDataDictionary model, CancellationToken cancellationToken = default);
    }
}
