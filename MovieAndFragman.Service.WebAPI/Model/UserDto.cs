using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAndFragman.Service.WebAPI.Model
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
