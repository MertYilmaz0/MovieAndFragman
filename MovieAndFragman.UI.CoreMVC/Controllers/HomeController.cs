using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetFragman([FromBody] List<FragmanVM> fragmanVMs)
        {
            if (fragmanVMs == null)
            {
                ViewBag.Message = "Listelenecek Film Bulunamadı";
            }
            return PartialView("_singleFragman", fragmanVMs);
        }
    }
}
