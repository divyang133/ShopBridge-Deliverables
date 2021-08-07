using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Entities
{
    public class tblProductDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PDID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(4000)")]
        [StringLength(4000, ErrorMessage = "Please, enter valid product name!", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        [MinLength(3, ErrorMessage = "Please, enter valid description name!")]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^(?!0*\.0+$)\d*(?:\.\d+)?$", ErrorMessage = "Please, enter valid price!")]
        public double Price { get; set; }
        public int DiscountInPercentage { get; set; }
        [StringLength(255, ErrorMessage = "Please, enter valid brand name!", MinimumLength = 3)]
        public string Brand { get; set; }
        [StringLength(255, ErrorMessage = "Please, enter valid manufacturer name!", MinimumLength = 3)]
        public string Manufacturer { get; set; }
        public bool IsReturnable { get; set; }
        public bool IsReplaceable { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please, enter valid status!", MinimumLength = 3)]
        public string Status { get; set; }
    }
}
