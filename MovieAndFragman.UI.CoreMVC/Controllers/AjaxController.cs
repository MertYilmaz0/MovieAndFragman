using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Helper;
using MovieAndFragman.UI.CoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Controllers
{
    public class AjaxController : Controller
    {
        [HttpGet]
        public IActionResult GetThird()
        {
            try
            {
                List<FragmanVM> vms = ApiJsonHelper<FragmanVM>.GetApiEntityList("fragman/GetLastThirdFragman");
                return PartialView("_singleSwiper", vms);
            }
            catch (Exception)
            {
                return PartialView("_error");
            }
        }
        [HttpGet]
        public IActionResult GetAllFragman()
        {
            try
            {
                List<FragmanVM> vms = ApiJsonHelper<FragmanVM>.GetApiEntityList("Fragman/GetAllFragman");
                return PartialView("_singleFragman", vms);
            }
            catch (Exception)
            {
                return PartialView("_error");
            }
        }
        //[HttpGet]
        //public IActionResult GetFragmansByCId(int id)
        //{
        //    List<FragmanVM> vms = ApiJsonHelper<FragmanVM>.GetApiEntityList("fragman/GetByGenreId?id=" + id);
        //    if (vms.Count == 0)
        //    {
        //        return PartialView("_nullMovie");
        //    }
        //    return PartialView("_singleMovie", vms);
        //}
        //[HttpGet]
        //public IActionResult GetFragmansByName(string name)
        //{
        //    List<FragmanVM> vms = ApiJsonHelper<FragmanVM>.GetApiEntityList("fragman/GetByName?name=" + name);
        //    if (vms.Count == 0)
        //    {
        //        return PartialView("_nullMovie");
        //    }
        //    return PartialView("_singleMovie", vms);
        //}
        [HttpGet]
        public IActionResult AddRating(int fid, int uid)
        {
            try
            {
                PostVM vm = ApiJsonHelper<PostVM>.GetApi("fragman/AddRating?fid=" + fid + "&uid=" + uid);
                return Ok(vm);
            }
            catch (Exception)
            {
                return PartialView("_error");
            }
        }
        //[HttpPost]
        //public IActionResult RegisterUser([FromBody] RegisterUserVM registerUser)
        //{
        //    try
        //    {
        //        PostVM vm = ApiJsonHelper<RegisterUserVM>.PostApiEntity("user/RegisterUser", registerUser);
        //        return Ok(vm);
        //    }
        //    catch (Exception)
        //    {
        //        return PartialView("_error");
        //    }
        //}
        [HttpGet]
        public IActionResult Like(int fid, int uid, string token)
        {
            try
            {
                PostVM vm = ApiJsonHelper<PostVM>.GetApi("fragman/UpdateRating?fid=" + fid + "&uid=" + uid + "&token=" + token);
                return Ok(vm);
            }
            catch (Exception)
            {
                return PartialView("_error");
            }
        }
    }
}
