using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Movies()
        {
            return View();
        }
        public IActionResult MovieSinglePage()
        {
            return View();
        }
    }
}
