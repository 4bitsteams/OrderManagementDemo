using AutoMapper;
using Microsoft.AspNetCore.Http;
using OrderManagement.BLL.IManager;
using OrderManagement.DAL.Extensions;
using OrderManagement.DAL.IRepository;
using OrderManagement.Entity.Models;
using OrderManagement.Model.Extention;
using OrderManagementViewModel.ViewModels.Common;
using OrderManagementViewModel.ViewModels.SalesOrder;

namespace OrderManagement.BLL.Manager
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository _iOrderRepository;
        private IQueryDataDictionaryManager _IQueryDataDictionaryManager;
        private IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;

        public OrderManager(IMapper mapper, IOrderRepository iOrderRepository, IQueryDataDictionaryManager iQueryDataDictionaryManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _iOrderRepository = iOrderRepository;
            _IQueryDataDictionaryManager = iQueryDataDictionaryManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync()
        {
            var data = await _iOrderRepository.GetOrdersAsync(CancellationToken.None);
            var pp = _mapper.Map<List<OrderView>, List<OrderViewModel>>(data);
            return pp;
        }
        public async Task<OrderViewModel> GetOrderAsync(int key)
        {
            var data = await _iOrderRepository.GetOrderAsync(key);
            var pp = _mapper.Map<OrderView, OrderViewModel>(data);
            return pp;
        }


        public async Task<OrderEditViewModel> GetOrderForEditAsync(int key)
        {
            var data = await _iOrderRepository.GetOrderAsync(key);
            var pp = _mapper.Map<OrderView, OrderEditViewModel>(data);
            return pp;
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync(bool isActive, CancellationToken cancellationToken = default)
        {
            var data = await _iOrderRepository.GetOrdersAsync(isActive, cancellationToken);
            var pp = _mapper.Map<List<OrderView>, List<OrderViewModel>>(data);
            return pp;
        }
        public async Task<OrderDetailViewModel> GetOrderDetailAsync(int key)
        {
            var searchModel = await _IQueryDataDictionaryManager.GetQueryDataDictionaryAsync<SearchModel>(nameof(OrderManager));
            var data = await _iOrderRepository.GetOrderAsync(key);
            var pp = _mapper.Map<OrderView, OrderDetailViewModel>(data);
            pp.RequestedUrl = searchModel.RequestedUrl;
            return pp;
        }

        public async Task<SearchResult<IEnumerable<OrderViewModel>>> GetOrdersSearchResultAsync(SearchModel searchModel)
        {
            await _IQueryDataDictionaryManager.SetQueryDataDictionaryAsync(nameof(OrderManager), searchModel);
            var data = await _iOrderRepository.GetOrdersSearchResultAsync(searchModel);
            var dataMapped = _mapper.Map<IEnumerable<OrderView>, IEnumerable<OrderViewModel>>(data.Value);
            var result = new SearchResult<IEnumerable<OrderViewModel>>(dataMapped, data.TotalRows, data.PageRows, true, "");
            return result;
        }
        public async Task<IEnumerable<OrderExportViewModel>> GetOrdersExportResultAsync()
        {
            var searchModel = await _IQueryDataDictionaryManager.GetQueryDataDictionaryAsync<SearchModel>(nameof(OrderManager));
            var data = await _iOrderRepository.GetOrdersExportResultAsync(searchModel);
            var dataMapped = _mapper.Map<IEnumerable<RptOrderView>, IEnumerable<OrderExportViewModel>>(data);
            return dataMapped;
        }
        public async Task<DefaultPageViewModel<OrderCreateViewModel, SearchModel, SearchResult<IEnumerable<OrderViewModel>>>> GetOrdersDefaultPageViewModelAsync(SearchModel searchModel)
        {
            await Task.Yield();
            var OrdersData = await GetOrdersSearchResultAsync(searchModel);
            var returnModel = new DefaultPageViewModel<OrderCreateViewModel, SearchModel, SearchResult<IEnumerable<OrderViewModel>>>()
            {
                CreateorEditViewModel = new OrderCreateViewModel(),
                SearchOptionViewModel = searchModel,
                SearchResultViewModel = OrdersData
            };
            return returnModel;
        }
        public async Task<DefaultPageViewModel<OrderCreateViewModel, SearchModel, SearchResult<IEnumerable<OrderViewModel>>>> GetOrdersDefaultPageViewModelAfterDeleteAsync()
        {
            var searchModel = await _IQueryDataDictionaryManager.GetQueryDataDictionaryAsync<SearchModel>(nameof(OrderManager));
            searchModel.Page = 1;
            var returnModel = await GetOrdersDefaultPageViewModelAsync(searchModel);
            return returnModel;
        }
        public async Task<Result<bool>> CreateOrderAsync(OrderCreateViewModel model, CancellationToken cancellationToken = default)
        {
            var dataMapped = _mapper.Map<OrderCreateViewModel, Order>(model);
            var data = await _iOrderRepository.CreateOrderAsync(dataMapped);
            return data;
        }

        public async Task<Result<bool>> UpdateOrderAsync(OrderEditViewModel model)
        {
            var data = await _iOrderRepository.UpdateOrderAsync(model);
            return data;
        }
        public async Task<Result<bool>> DeleteOrderAsync(int key, CancellationToken cancellationToken = default)
        {
            var data = await _iOrderRepository.DeleteOrderAsync(key);
            return data;
        }
        public async Task<OrderDropDownViewModel> GetOrderDropDownViewModelAsync(bool isActive)
        {
            var data = await _iOrderRepository.GetOrdersAsync(isActive);
            var dataMapped = _mapper.Map<List<OrderView>, List<OrderViewModel>>(data);
            var dropDownViewModel = new OrderDropDownViewModel();
            dropDownViewModel.OrderViewModels = dataMapped;
            return dropDownViewModel;
        }

        public async Task<SearchModel> GetSearchModel()
        {
            var searchModel = await _IQueryDataDictionaryManager.GetQueryDataDictionaryAsync<SearchModel>(nameof(OrderManager));
            return searchModel;
        }


    }
}
