using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MovieAndFragman.UI.CoreMVC.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Areas.Admin.ViewComponents
{
    public class DBAdminViewComponent: ViewComponent
    {        
        public ViewViewComponentResult Invoke(string name)
        {
            AccountVM account = new AccountVM()
            {
                UserName = name,
                UserRole = name
            };
            return View(account);
        }
    }
}
