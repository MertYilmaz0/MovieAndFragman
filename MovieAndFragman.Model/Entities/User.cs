using MovieAndFragman.Core.Entity;
using MovieAndFragman.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAndFragman.Model.Entities
{
    public class User : BaseModel, IEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<Fragman> Fragmans { get; set; }
        public ICollection<Rating> Ratings { get; set; }//izlenme
        public ICollection<FragComment> FragComments { get; set; }//Yorum
        public Guid ActivationCode { get; set; }
        public UserRole UserRole { get; set; }

        public string Password { get; set; }//ignore edildi.
    }
}
