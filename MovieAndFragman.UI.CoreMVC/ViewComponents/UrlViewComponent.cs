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
    public class UrlViewComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke(int id)
        {
            List<UrlVM> urls= ApiJsonHelper<UrlVM>.GetApiEntityList("url/GetUrlByFragId?id=" + id);
            return View(urls);
        }
    }
}
