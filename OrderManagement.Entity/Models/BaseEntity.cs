using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Entity.Models
{
    public  class BaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }

        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
