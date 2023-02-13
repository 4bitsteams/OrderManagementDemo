using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.SalesOrder
{
    public class OrderEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Boolean IsActive { get; set; }
    }
}
