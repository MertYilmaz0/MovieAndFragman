using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieAndFragman.UI.CoreMVC.Controllers
{
    public class AccountController : Controller
    {

        //IUserBLL userBll;
        public AccountController()//IUserBLL bll
        {
            //userBLL=bll
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            UserVM userLogin = null;

            //Todo: UserVM userLogin=userBLL.GetUserByLoginData(login.Email,login.Password);  Normalde burada User kullanılıp datadan userların email ve passwordlari çekiliyordu... bunu şimdi api ile yapacağız..


            if (userLogin != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                   new Claim(ClaimTypes.Name,userLogin.Email),
                   new Claim(ClaimTypes.Role,userLogin.UserRole),
                   new Claim(ClaimTypes.UserData,userLogin.UserID.ToString()),
                   new Claim(ClaimTypes.NameIdentifier,userLogin.FirstName)

                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if (userLogin.UserRole == "User")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (userLogin.UserRole == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return View();
                }


            }
            else
            {
                ViewBag.Message = "Kullanıcı Bilgileriniz Kontrol Ediniz";
                return View();

            }




        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserVM userVM)
        {
            //Todo: Model User çağrılması gerekiyor fakat modeli buraya referans vermeyeceğimiz için bu işlemi ap ile yapacağız

            return View();
        }
    }
}
