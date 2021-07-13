using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Models;

namespace WebApp.Models.Cars
{
    public class CreateCarFormModel
    {
        
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
        
        public string Color { get; set; }
        
        public string PlateNumber { get; set; }
        
     //   public string FuelType { get; set; }
        
        public string VinNumber { get; set; }
        
        public string PictureUrl { get; set; }

        public string Description { get; set; }
        [Display (Name = "FuelType")]
        public string FuelTypeId { get; set; }
        public IEnumerable<FuelTypeViewModel> FuelTypes { get; set; }
    }
}
