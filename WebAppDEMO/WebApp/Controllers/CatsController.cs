using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CatsController : Controller
    {
        //public IActionResult All(string name=null)
        //{
        //    var cats = new List<CatViewModel>
        //    {
        //        new CatViewModel
        //        {
        //            Name = "Sharo",
        //            Age = 5
        //        },
        //        new CatViewModel
        //        {
        //            Name = "Caty",
        //            Age = 8
        //        }
        //    };
        //    if (name==null)
        //    {
        //        cats=cats
        //            .Where(c=>c.Name.ToLower().StartsWith("ca")).ToList();
        //    }
        //    return View(cats);
        //}

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CatFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Ok();
        }
    }
}
