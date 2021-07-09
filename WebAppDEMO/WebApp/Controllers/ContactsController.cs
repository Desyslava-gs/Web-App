using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        // GET: ContactsController1
        public ActionResult Contacts()
        {
            return View();
        }
    }


}
