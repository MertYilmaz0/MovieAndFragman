using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Helper;
using MovieAndFragman.UI.CoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Movies()
        {
            return View();
        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult MovieSinglePage(int id)
        {
            FragmanVM fragmanVM = ApiJsonHelper<FragmanVM>.GetApiEntity("fragman/Get?id=" + id);
            if (fragmanVM != null)
            {
                ViewBag.UId = User.FindFirstValue(ClaimTypes.UserData);
                return View(fragmanVM);
            }
            ViewBag.Alert = "Böyle bir fragman bulunmamaktadır.";
            return RedirectToAction("index", "home");
        }
        [HttpPost]
        public IActionResult LastThird([FromBody] List<FragmanVM> fragmanVM)
        {
            return PartialView("_SingleSwiper", fragmanVM);
        }
        [HttpPost]
        public IActionResult GetMovieList([FromBody] List<FragmanVM> fragmanVMs)
        {
            if (fragmanVMs.Count == 0)
            {
                return PartialView("_nullMovie");
            }
            return PartialView("_singleMovie", fragmanVMs);
        }

        [HttpGet]
        public IActionResult GetRating(int id)
        {
            RatingVM ratingVM = ApiJsonHelper<RatingVM>.GetApiEntity("fragman/GetFragRating?id=" + id);
            return PartialView("_rating", ratingVM);
        }

        
    }
}
