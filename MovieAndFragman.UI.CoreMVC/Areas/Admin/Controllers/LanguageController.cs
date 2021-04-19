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
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GetLanguageList([FromBody] List<LanguageVM> languages)
        {
            if (languages==null)
            {
                ViewBag.Message = "Diller Listelenemiyor";
            }
            return PartialView("_languageList",languages);
        }

        public IActionResult AddLanguage()
        {
            return View();
        }

        public IActionResult UpdateLanguage()
        {
            return View();
        }
    }
}
