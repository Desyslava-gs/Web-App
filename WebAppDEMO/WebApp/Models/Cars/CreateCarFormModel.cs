using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;
using WebApp.Infrastructure;
using static WebApp.Data.DataConstants;
namespace WebApp.Models.Cars
{
    public class CreateCarFormModel
    {
        //[Key]
        //[Required]
        //public string Id { get; set; }


        [Required]
        [StringLength(CarMakeMaxLength, MinimumLength = CarMakeMinLength)]
        public string Make { get; set; }

        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; set; }


        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; set; }
        [Required]
        [StringLength(CarColorMaxLength, MinimumLength = CarColorMinLength)]
        public string Color { get; set; }

        [Required]
        [MaxLength(CarPlateNumberMaxLength)]
        [RegularExpression("^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
        public string PlateNumber { get; set; }

        [Required]
        [StringLength(CarVinNumberMaxLength, MinimumLength = CarVinNumberMinLength)]
        public string VinNumber { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }
        [Required]
        [StringLength(
            int.MaxValue, 
            MinimumLength = CarDescriptionMinLength, 
            ErrorMessage = "The field Description must be minimum length of {2}.")]
        public string Description { get; set; }

      //  [Display(Name = "Fuel Type")]
        public string FuelTypeId { get; set; }
        [Required]
        public IEnumerable<FuelTypeViewModel> FuelTypes { get; set; }
    }
}
