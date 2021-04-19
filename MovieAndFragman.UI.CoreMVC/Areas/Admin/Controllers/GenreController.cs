using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class GenreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddGenre()
        {
            return View();
        }

        public IActionResult UpdateGenre()
        {
            return View();
        }

       [HttpPost]
       public IActionResult GetGenreList([FromBody] List<GenreVM> genres)
        {
            if (genres==null)
            {
                ViewBag.Message = "Türler Listelenemiyor";
            }
            return PartialView("_genreList", genres);
        }
    }
}
