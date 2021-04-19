using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MovieAndFragman.UI.CoreMVC.Helper;
using MovieAndFragman.UI.CoreMVC.Models.MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.ViewComponents
{
    public class MyListViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            MyList myCart = HttpContext.Session.Get<MyList>("myList");
            List<ListItem> listIts = myCart.GetAllCartItem;
            return View(listIts);
        }
    }
}
