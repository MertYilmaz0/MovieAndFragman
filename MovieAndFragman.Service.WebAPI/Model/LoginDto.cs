using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
    }
}
