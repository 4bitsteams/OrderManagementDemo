using OrderManagementViewModel.ViewModels.SalesOrder;

namespace OrderManagement.BLL.IManager
{
    public interface IOrderManager
    {
        Task<List<OrderViewModel>> GetOrdersAsync();
        Task<OrderViewModel> GetOrderAsync(int key);
        //Task<List<OrderViewModel>> GetOrdersAsync(bool isActive, CancellationToken cancellationToken = default);
        //Task<OrderEditViewModel> GetOrderForEditAsync(int key);
        //Task<Result<bool>> UpdateOrderAsync(OrderEditViewModel model);
        //Task<SearchResult<IEnumerable<OrderViewModel>>> GetOrdersSearchResultAsync(SearchModel searchModel);
        //Task<DefaultPageViewModel<OrderCreateViewModel, SearchModel, SearchResult<IEnumerable<OrderViewModel>>>> GetOrdersDefaultPageViewModelAsync(SearchModel searchModel);
        //Task<DefaultPageViewModel<OrderCreateViewModel, SearchModel, SearchResult<IEnumerable<OrderViewModel>>>> GetOrdersDefaultPageViewModelAfterDeleteAsync();
        //Task<IEnumerable<OrderExportViewModel>> GetOrdersExportResultAsync();
        //Task<Result<bool>> CreateOrderAsync(OrderCreateViewModel model, CancellationToken cancellationToken = default);
        //Task<Result<bool>> DeleteOrderAsync(int key, CancellationToken cancellationToken = default);
        //Task<OrderDropDownViewModel> GetOrderDropDownViewModelAsync(bool isActive);

        //Task<OrderDetailViewModel> GetOrderDetailAsync(int key);
        //Task<SearchModel> GetSearchModel();

    }
}
