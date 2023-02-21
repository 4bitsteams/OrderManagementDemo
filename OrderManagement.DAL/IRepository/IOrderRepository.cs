using OrderManagement.Entity.Models;

namespace OrderManagement.DAL.IRepository
{
    public interface IOrderRepository
    {
        //IQueryable<Order> GetOrdersQuery();
        Task<Order> GetOrderAsync(int key, CancellationToken cancellationToken = default);
        Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken);
        //Task<List<Order>> GetOrdersAsync(bool isActive, CancellationToken cancellationToken = default);
        //Task<SearchResult<IEnumerable<Order>>> GetOrdersSearchResultAsync(SearchModel searchModel, CancellationToken cancellationToken = default);
        //Task<Result<bool>> CreateOrderAsync(Order model, CancellationToken cancellationToken = default);
        //Task<Result<bool>> UpdateOrderAsync(OrderEditViewModel model, CancellationToken cancellationToken = default);
        //Task<Result<bool>> DeleteOrderAsync(int key, CancellationToken cancellationToken = default);
        //Task<IEnumerable<RptOrderView>> GetOrdersExportResultAsync(SearchModel searchModel, CancellationToken cancellationToken = default);
        //Task<List<Order>> GetOrderModelByOrderIdsAsync(List<int> OrderIds, CancellationToken cancellationToken = default);
    }
}
