using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CloudIceTaskShopInventory.Models
{
    public class Inventory
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Date Ordered")]
        [DataType(DataType.Date)]
        public DateTime? LastOrderedOn { get; set; }

        public int? Quantity { get; set; }

        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        
        [Display(Name = "Category")]
        public string? Catogory { get; set; }
    }
}

   