using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Cars;

namespace WebApp.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {
            return View();
        }

    }
} 
