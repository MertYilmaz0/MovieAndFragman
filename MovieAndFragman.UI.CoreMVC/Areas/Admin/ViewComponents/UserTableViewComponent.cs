using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.ViewComponents
{
    public class UserTableViewComponent: ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
