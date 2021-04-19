using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MovieAndFragman.UI.CoreMVC.Areas.Admin.Models;
using MovieAndFragman.UI.CoreMVC.Helper;
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
            List<UserVM> vms = ApiJsonHelper<UserVM>.GetApiEntityList("user/GetAll");
            return View(vms);
        }
    }
}
