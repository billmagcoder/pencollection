using System;
using System.ComponentModel.DataAnnotations;

namespace Pens.Core.Models
{
    public class Pen
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Brand { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Purchased Date")]
        public DateTime PurchasedDate { get; set; }

        [Display(Name="Type of Pen")]
        public PenType Type { get; set; }
    }
}
