using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class User
    {
        public User()
        {
        }
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
