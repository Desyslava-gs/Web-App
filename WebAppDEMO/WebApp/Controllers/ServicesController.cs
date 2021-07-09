using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ServicesController : Controller
    {
        //public IActionResult Article(string date, string id)
        //{
        //    return Ok($"{date} - {id}");
        //}

        public IActionResult Services()
        {
            return View();
        }
    }
}
