using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
 
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult AddMovie()
        {
            return View();
        }
        public IActionResult UpdateMovie()
        {
            return View();
        }
    }
}
