using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Cars;
using static WebApp.Data.DataConstants;

namespace WebApp.Data.Models
{

    public class Car
    {
        [Key]
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; }

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; set; }

        [MaxLength(CarColorMaxLength)]
        public string Color { get; set; }

        [Required]
        [MaxLength(CarPlateNumberMaxLength)]
        public string PlateNumber { get; set; }

        [Required]
        [MaxLength(CarVinNumberMaxLength)]
        public string VinNumber { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public string Description { get; set; }
         
        public string FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        
        public IEnumerable<Repair> Repairs { get; set; } = new List<Repair>();
    }
}
