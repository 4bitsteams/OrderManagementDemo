using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.Common
{
    public class ViewModelBase
    {
        public string? RequestedUrl { get; set; }
        public string? CurrentUrl { get; set; }
        public string? ReturnUrl { get; set; }
        public SearchModel? SearchModel { get; set; }
        public virtual bool CanView { get; set; }
        public virtual bool CanUpdate { get; set; }
        public virtual bool CanDelete { get; set; }
        public virtual bool CanApprove { get; set; }
        public virtual bool CanViewMenu { get; set; }
        public virtual bool CanCreate { get; set; }

    }

    public class ViewModelBase<TModel> : ViewModelBase
    {
        public TModel? KeyValue { get; set; }
        public bool Success { get; set; }
        public bool HasRecord { get; set; }
        public string? Message { get; set; }
    }
}
