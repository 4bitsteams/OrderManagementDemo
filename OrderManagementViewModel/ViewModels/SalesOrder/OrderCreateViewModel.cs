using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.SalesOrder
{
    public  class OrderCreateViewModel
    {
        public string Name { get; set; } = string.Empty;
        public Boolean IsActive { get; set; }
    }
}
