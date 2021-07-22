using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebApp.Data.Models
{
    public class Repair
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string TypeOfRepair { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        // [MaxLength(CarModelMaxLength)]
        public string StartDate { get; set; }

        // [MaxLength(CarModelMaxLength)]
        public string EndDate { get; set; }

        public string CarId { get; set; }
        public  Car Car { get; init; }
    }
}
