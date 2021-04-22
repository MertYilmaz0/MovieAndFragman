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
    public class MoviesByGViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke(int id)
        {
            try
            {
                List<FragmanVM> vms = ApiJsonHelper<FragmanVM>.GetApiEntityList("fragman/GetByGenreId?id=" + id);
                return View(vms);
            }
            catch (Exception)
            {
                List<FragmanVM> vms = new List<FragmanVM>();
                return View(vms);
            }
        }
    }
}
