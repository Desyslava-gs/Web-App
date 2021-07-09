﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CatFormModel
    { [Required]
        public string Name { get; set; }

        [Range(0,20)]
        public int Age { get; set; }

    }
}