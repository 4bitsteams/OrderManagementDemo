using Microsoft.EntityFrameworkCore;
using OrderManagement.DAL.ApplicationDbContext;
using OrderManagement.DAL.Extensions;
using OrderManagement.DAL.IRepository;
using OrderManagement.Entity.Models;

namespace OrderManagement.DAL.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        internal static class CacheKeyDictionary
        {
            public static string ROrderSearchCacheKey => "Order.Search";
            public static string ROrderExportCacheKey => "Order.Export";
            public static string ROrderByIdCacheKey => "Order.Order_{0}";
            public static string ROrderSearchOPtionCacheKey => "Order.Order_SearchOPtion";
        }
        private readonly OrderDbContext _context;
       // private ICacheManager _iCacheManager;
        public OrderRepository(OrderDbContext context/*, ICacheManager iCacheManager*/) : base(context)
        {
            this._context = context;
            //_iCacheManager = iCacheManager;
        }

        public IQueryable<Order> GetOrdersQuery()
        {
            return _context.Orders.AsQueryable();
        }
        public async Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested == false)
            {
                var data = await _context.Orders.ToListAsync();
                return data;
            }
            return null;
        }

        //public async Task<List<Order>> GetOrdersAsync(bool isActive, CancellationToken cancellationToken = default)
        //{
        //    if (cancellationToken.IsCancellationRequested == false)
        //    {
        //        var data = await _context.Orders.Where(x => x.IsActive == isActive && x.IsDeleted != true).ToListAsync();
        //        return data;
        //    }
        //    return null;
        //}

        public async Task<Order> GetOrderAsync(int key, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested == false)
            {
                var data = await _context.Orders.FirstOrDefaultAsync(x => x.Id == key);
                return data;
            }
            return null;
        }


        //public async Task<List<Order>> GetOrderModelByOrderIdsAsync(List<int> OrderIds, CancellationToken cancellationToken = default)
        //{
        //    if (cancellationToken.IsCancellationRequested == false)
        //    {
        //        return await _context.Orders.Where(x => OrderIds.Contains(x.Id)).ToListAsync();
        //    }
        //    return null;
        //}

        //public async Task<SearchResult<IEnumerable<Order>>> GetOrdersSearchResultAsync(SearchModel searchModel, CancellationToken cancellationToken = default)
        //{
        //    var key = CacheKeyDictionary.ROrderSearchCacheKey;

        //    if (cancellationToken.IsCancellationRequested == false)
        //    {
        //        string st = searchModel.SearchText?.Trim().ToLower();
        //        var query = _context.Orders.Where(x => x.IsDeleted != true).AsQueryable();
        //        if (!string.IsNullOrEmpty(searchModel.SearchText))
        //        {
        //            query = query.Where(x => x.Name.ToLower().Contains(st));
        //        }
        //        var count = await query.CountAsync();
        //        var dataQuery = query.OrderByName(searchModel.SortColumn, searchModel.IsDescending)
        //            .Skip((searchModel.GetCurrentPage() - 1) * (searchModel.Rows)).Take(searchModel.Rows);

        //        var data = await _iCacheManager.Get(key, async () => await dataQuery.ToListAsync());
        //        return new SearchResult<IEnumerable<Order>>(data, count, data.Count, true, "");
        //    }
        //    return null;
        //}

        //public async Task<IEnumerable<RptOrderView>> GetOrdersExportResultAsync(SearchModel searchModel, CancellationToken cancellationToken = default)
        //{
        //    var key = CacheKeyDictionary.ROrderExportCacheKey;

        //    if (cancellationToken.IsCancellationRequested == false)
        //    {
        //        string st = searchModel.SearchText?.Trim().ToLower();

        //        var query = _context.Orders.Where(x => x.IsDeleted != true).AsQueryable();
        //        if (!string.IsNullOrEmpty(searchModel.SearchText))
        //        {
        //            query = query.Where(x => x.Name.ToLower().Contains(st));
        //        }
        //        var dataQuery = query.OrderByName(searchModel.SortColumn, searchModel.IsDescending);
        //        var data = await _iCacheManager.Get(key, async () => await dataQuery.ToListAsync());
        //        return (IEnumerable<RptOrderView>)data;
        //    }
        //    return null;
        //}

        public async Task<Result<bool>> CreateOrderAsync(Order model, CancellationToken cancellationToken = default)
        {
            Result<bool> result = Result.Ok<bool>(false);
            int count = 0;
            if (cancellationToken.IsCancellationRequested == false)
            {
                var exists = await _context.Orders.AnyAsync(
                    x => x.Name.Trim().ToLower() == model.Name.Trim().ToLower() && x.Id == model.Id);
                if (exists == false)
                {
                    await _context.Orders.AddAsync(model, cancellationToken);
                    count = await _context.SaveChangesAsync(cancellationToken);
                    result = Result.Ok(true, "Record has been created successfully.");
                }
                else
                {
                    result = Result.Exists(false, false, $"Record already exists for {model.Name}.");
                }
                return result;
            }
            return result;
        }

        //public async Task<Result<bool>> UpdateOrderAsync(OrderEditViewModel model, CancellationToken cancellationToken = default)
        //{
        //    Result<bool> result = Result.Ok<bool>(false);
        //    int count = 0;
        //    if (cancellationToken.IsCancellationRequested == false)
        //    {
        //        var exists = await _context.Orders.AsNoTracking().AnyAsync(
        //            x => x.Name.Trim().ToLower() == model.Name.Trim().ToLower() && x.Id != model.Id && x.IsDeleted != true);
        //        if (exists == false)
        //        {
        //            var original = await _context.Orders.FirstOrDefaultAsync(x => x.Id == model.Id);
        //            _context.Entry<Order>(original).CurrentValues.SetValues(model);
        //            count = await _context.SaveChangesAsync(cancellationToken);
        //            result = Result.Ok(true, "Record has been updated successfully.");
        //        }
        //        else
        //        {
        //            result = Result.Exists(false, false, $"Record already exists for {model.Name}.");
        //        }
        //        return result;
        //    }
        //    return result;
        //}

        //public async Task<Result<bool>> DeleteOrderAsync(int key, CancellationToken cancellationToken = default)
        //{
        //    Result<bool> result = Result.Ok<bool>(false);

        //    if (cancellationToken.IsCancellationRequested == false)
        //    {
        //        var exists = await _context.Orders.FirstOrDefaultAsync(
        //            x => x.Id == key);
        //        if (exists != null)
        //        {
        //            var order = _context.Orders.Remove(exists);
        //            if (order != null)
        //                Result.Ok(true, "Record Deleted SuccessFull.");

        //        }
        //        else
        //        {
        //            result = Result.Fail(true, "Record not found.");
        //        }
        //        return result;
        //    }
        //    return result;
        //}
    }
}
