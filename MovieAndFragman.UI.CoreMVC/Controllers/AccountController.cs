using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.UI.CoreMVC.Helper;
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

            //Todo: UserVM userLogin=userBLL.GetUserByLoginData(login.Email,login.Password);  Normalde burada User kullanılıp datadan userların email ve passwordlari çekiliyordu... bunu şimdi api ile yapacağız..

            LoginUserVM userLogin = PostHelper<LoginVM, LoginUserVM>.PostApiEntity("user/LoginUser", loginVM);

            if (!userLogin.Check)
            {
                ViewBag.Message = userLogin.Message;
                ViewBag.Check = userLogin.Check;
                return View();
            }
            else if (userLogin.Check)
            {
                List<Claim> claims = new List<Claim>()
                {
                   new Claim(ClaimTypes.Name,userLogin.Email),
                   new Claim(ClaimTypes.Role,userLogin.UserRole),
                   new Claim(ClaimTypes.UserData,userLogin.UserID.ToString()),
                   new Claim(ClaimTypes.NameIdentifier,userLogin.UserName)

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
        public IActionResult Register(RegisterUserVM userVM)
        {
            PostVM postVM = ApiJsonHelper<RegisterUserVM>.PostApiEntity("user/RegisterUser", userVM);
            ViewBag.Message = postVM.Message;
            ViewBag.Check = postVM.Check;
            return View();
        }
    }
}
