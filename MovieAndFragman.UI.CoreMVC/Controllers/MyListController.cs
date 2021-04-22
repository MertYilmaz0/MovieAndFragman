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
            try
            {
                FragmanVM fragmanVM = ApiJsonHelper<FragmanVM>.GetApiEntity("fragman/Get?id=" + id);
                bool ck = false;
                if (fragmanVM != null)
                {
                    MyList myCart = HttpContext.Session.Get<MyList>("myList");
                    ListItem item = new ListItem() { Id = id, Name = fragmanVM.Name };
                    ck = myCart.AddCart(item);
                }
                return Ok(new { check = ck });
            }
            catch (Exception)
            {
                return Ok(new { check = false });
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                MyList deleted = HttpContext.Session.Get<MyList>("myList");
                deleted.DeleteCart(id);
                HttpContext.Session.Set<MyList>("myList", deleted);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        [HttpGet]
        public IActionResult GetBtn()
        {
            try
            {
                MyList myCart = HttpContext.Session.Get<MyList>("myList");
                List<ListItem> listIts = myCart.GetAllCartItem;                
                return PartialView("_btnMylist", listIts);
            }
            catch (Exception)
            {
                List<ListItem> error = new List<ListItem>()
                {
                    new ListItem()
                    {
                        Id=-1,
                        Name="Şuanda oynatma listesi görüntülenemiyor."
                    }
                };
                return PartialView("_btnMylist", error);
            }
        }
    }
}
