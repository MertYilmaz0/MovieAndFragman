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
        public IActionResult SPL()
        {
            return View();
        }
        public IActionResult DailyGif()
        {
            return View();
        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult MovieSinglePage(int id)
        {
            try
            {
                FragmanVM fragmanVM = ApiJsonHelper<FragmanVM>.GetApiEntity("fragman/Get?id=" + id);
                if (fragmanVM != null)
                {
                    ViewBag.UId = User.FindFirstValue(ClaimTypes.UserData);
                    return View(fragmanVM);
                }
                return RedirectToAction("NotFoundError", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("NotFoundError", "Home");
            }
        }


        [HttpGet]
        public IActionResult GetRating(int id)
        {
            try
            {
                RatingVM ratingVM = ApiJsonHelper<RatingVM>.GetApiEntity("fragman/GetFragRating?id=" + id);
                return PartialView("_rating", ratingVM);
            }
            catch (Exception)
            {
                return PartialView("_ratingError");
            }
        }
    }
}
