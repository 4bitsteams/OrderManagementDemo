using AutoMapper;
using Microsoft.AspNetCore.Http;
using OrderManagement.BLL.IManager.Common;
using OrderManagement.DAL.IRepository.Common;
using OrderManagementViewModel.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.BLL.Manager.Common
{
    public class QueryDataDictionaryManager : IQueryDataDictionaryManager
    {
        internal IQueryDataDictionaryRepository _IQueryDataDictionaryRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public IMapper _mapper { get; private set; }

        public QueryDataDictionaryManager(IMapper mapper, IQueryDataDictionaryRepository _iQueryDataDictionaryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _IQueryDataDictionaryRepository = _iQueryDataDictionaryRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<T> GetQueryDataDictionaryAsync<T>(string formKey)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.AppUserId();
            var data = await _IQueryDataDictionaryRepository.GetQueryDataDictionaryAsync(formKey, userId);
            if (data != null)
            {
                var result = data.FormValue.ToJsonObject<T>();
                return result;
            }
            return default;
        }

        public async Task<int> SetQueryDataDictionaryAsync(string formKey, object model = default)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.AppUserId();
            var url = _httpContextAccessor.HttpContext?.Request?.GetTypedHeaders().Referer?.ToString();
            if (!_httpContextAccessor.HttpContext.Request.IsAjaxRequest())
            {
                url = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();
            }
            if (model != null && model.GetType() == typeof(SearchModel))
            {
                ((SearchModel)model).RequestedUrl = url;
            }
            else if (model != null)
            {
                var mm = model as ViewModelBase;
                if (mm != null)
                {
                    mm.RequestedUrl = url;
                }
            }
            QueryDataDictionary data = new QueryDataDictionary()
            {
                FormKey = formKey,
                FormValue = model.ToJsonString(),
                UserId = userId
            };
            var result = await _IQueryDataDictionaryRepository.UpdateQueryDataDictionaryAsync(formKey, data);
            return result;
        }
        public async Task<int> SetQueryDataDictionaryByUrlAsync(string formKey, object model = default)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.AppUserId();

            var searchModel = new SearchModel();
            if (model.GetType() == typeof(SearchModel))
            {
                searchModel = (SearchModel)model;
            }

            QueryDataDictionary data = new QueryDataDictionary()
            {
                FormKey = formKey,
                FormValue = searchModel.ToJsonString(),
                UserId = userId
            };
            var result = await _IQueryDataDictionaryRepository.UpdateQueryDataDictionaryAsync(formKey, data);
            return result;
        }
        public string EncQueryDataDictionary(object model)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.AppUserId();
            if (model.GetType() == typeof(SearchModel))
            {
                ((SearchModel)model).RequestedUrl = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();
                return OHCryptographyHelper.EncryptString(model.ToJsonString());
            }
            return "";
        }
        public T DecQueryDataDictionary<T>(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var str = OHCryptographyHelper.DecryptString(data);
                return str.ToJsonObject<T>();
            }
            return default;
        }
    }
}
