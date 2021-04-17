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
    public class FragmanViewComponent: ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            List<FragmanVM> fragmanVM = ApiJsonHelper<FragmanVM>.GetApiEntityList("fragman/GetLastThirdFragman");
            return View(fragmanVM);
        }
    }
}
