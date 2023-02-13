using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.SalesOrder
{
    public  class OrderDropDownViewModel
    {
        public OrderDropDownViewModel()
        {
            OrderViewModels = new List<OrderViewModel>();
        }

        public List<OrderViewModel> OrderViewModels { get; set; }
    }
}
