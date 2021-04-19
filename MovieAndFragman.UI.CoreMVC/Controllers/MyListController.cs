using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Areas.Admin.Models;
using MovieAndFragman.UI.CoreMVC.Helper;
using MovieAndFragman.UI.CoreMVC.Models.MyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Controllers
{
    public class MyListController : Controller
    {
        public IActionResult AddMyList(int id)
        {
            FragmanVM fragmanVM = ApiJsonHelper<FragmanVM>.GetApiEntity("fragman/Get?id=" + id);
            bool ck=false;
            if (fragmanVM != null)
            {
                MyList myCart = HttpContext.Session.Get<MyList>("myList");
                ListItem item = new ListItem() { Id = id, Name = fragmanVM.Name };
                ck=myCart.AddCart(item);
            }
            return Ok(new { check = ck });
        }
        public IActionResult Delete(int id)
        {
            MyList deleted = HttpContext.Session.Get<MyList>("myList");
            deleted.DeleteCart(id);
            HttpContext.Session.Set<MyList>("myList", deleted);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBtn()
        {
            MyList myCart = HttpContext.Session.Get<MyList>("myList");
            List<ListItem> listIts = myCart.GetAllCartItem;
            return PartialView("_btnMylist", listIts);
        }
    }
}
