using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MovieAndFragman.UI.CoreMVC.Helper;
using MovieAndFragman.UI.CoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.ViewComponents
{
    public class MovieIndexViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            try
            {
                List<GenreVM> categories = ApiJsonHelper<GenreVM>.GetApiEntityList("genre/GetAllCategories");
                return View(categories);
            }
            catch (Exception)
            {
                List<GenreVM> categories = new List<GenreVM>();
                return View(categories);
            }
        }
    }
}
