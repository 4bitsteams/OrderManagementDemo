using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.SalesOrder
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int DeletedByName { get; set; }
        public DateTime DeletedDate { get; set; }

        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
