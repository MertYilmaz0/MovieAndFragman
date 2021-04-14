using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAndFragman.BLL.Abstract;
using MovieAndFragman.Model.Entities;
using MovieAndFragman.Service.WebAPI.Attributes;
using MovieAndFragman.Service.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKey]
    public class UserController : ControllerBase
    {
        IUserBLL userBLL;
        public UserController(IUserBLL bLL)
        {
            userBLL = bLL;
        }

        User ConvertUser(RegisterUserDto userDto)
        {
            User register = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                BrithDate = userDto.BrithDate,
                Email = userDto.Email,
                Password = userDto.Password,
                PhoneNumber = userDto.PhoneNumber,
                UserName = userDto.UserName
            };
            return register;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserDto registerUserDto)
        {
            try
            {
                userBLL.Insert(ConvertUser(registerUserDto));
                return Ok(new { Message = "Kullanıcı eklendi.", Check = true });
            }
            catch (Exception ex)
            {
                return Ok(new { Message = ex.Message, Check = false });
            }
        }
        [HttpPost]
        public IActionResult LoginUser(LoginDto loginDto)
        {
            try
            {
                User login = userBLL.GetLoginUser(loginDto.Email, loginDto.Password);
                LoginUserDto userDto = new LoginUserDto()
                {
                    Email = login.Email,
                    UserID = login.ID,
                    UserName = login.UserName,
                    UserRole = login.UserRole.ToString(),
                    Check = true
                };
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                LoginUserDto userDto = new LoginUserDto()
                {
                    Check = false,
                    Message = ex.Message
                };
                return Ok(userDto);
            }
        }
    }
}
