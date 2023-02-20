using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Entity.Models
{
    public  class Order 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
