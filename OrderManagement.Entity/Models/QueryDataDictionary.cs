using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementViewModel.ViewModels.Common
{
    [Table("QueryDataDictionary", Schema = "std")]
    public partial class QueryDataDictionary
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(250)]
        public string FormKey { get; set; } = default!;
        public int? UserId { get; set; }
        public string? FormValue { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }
    }
}
