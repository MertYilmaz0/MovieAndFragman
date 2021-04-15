using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Models;
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
        [HttpPost]
        public IActionResult LastThird([FromBody] List<FragmanVM> fragmanVM)
        {
            return PartialView("_SingleSwiper", fragmanVM);
        }
    }
}
