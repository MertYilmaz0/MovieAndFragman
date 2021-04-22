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
    public class GenreViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(int FragId)
        {
            try
            {
                List<GenreVM> genres = ApiJsonHelper<GenreVM>.GetApiEntityList("genre/GetGenreListByFragId?id=" + FragId);
                return View(genres);
            }
            catch (Exception)
            {
                List<GenreVM> genres = new List<GenreVM>();
                return View(genres);
            }
        }
    }
}
