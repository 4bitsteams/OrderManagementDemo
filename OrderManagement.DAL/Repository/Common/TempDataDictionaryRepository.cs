using Microsoft.EntityFrameworkCore;
using OrderManagement.DAL.ApplicationDbContext;
using OrderManagement.DAL.IRepository.Common;
using OrderManagementViewModel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.DAL.Repository.Common
{
    public class QueryDataDictionaryRepository : IQueryDataDictionaryRepository
    {
        private readonly OrderDbContext _context;

        public QueryDataDictionaryRepository(OrderDbContext context)
        {
            this._context = context;
        }

        public async Task<QueryDataDictionary> GetQueryDataDictionaryAsync(string formKey, int userId, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested == false)
            {
                var data = await _context.QueryDataDictionary.AsNoTracking().Where(x => x.FormKey == formKey && x.UserId == userId).FirstOrDefaultAsync();
                return data;
            }
            return null;
        }
        public async Task<int> InsertQueryDataDictionaryAsync(string formKey, QueryDataDictionary model, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested == false)
            {
                model.Id = Guid.NewGuid();
                _context.QueryDataDictionary.Add(model);
                var count = await _context.SaveChangesAsync();
                return count;
            }
            return 0;
        }
        public async Task<int> UpdateQueryDataDictionaryAsync(string formKey, QueryDataDictionary model, CancellationToken cancellationToken = default)
        {
            int count = 0;
            if (cancellationToken.IsCancellationRequested == false)
            {
                var dataOriginal = await _context.QueryDataDictionary.Where(x => x.FormKey == formKey && x.UserId == model.UserId).FirstOrDefaultAsync();
                if (dataOriginal == null)
                {
                    count = await InsertQueryDataDictionaryAsync(formKey, model, cancellationToken);
                }
                else
                {
                    model.Id = dataOriginal.Id;
                    _context.Entry(dataOriginal).CurrentValues.SetValues(model);
                    count = await _context.SaveChangesAsync();

                }
                return count;
            }
            return 0;
        }

    }
}
