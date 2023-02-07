using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Entity.Models
{
    public  class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

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
