﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Cars
{
    public class FuelTypeViewModel
    {   
        [Key]
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
