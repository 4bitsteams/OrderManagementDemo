using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Entity.Models
{
    public  class Order : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
