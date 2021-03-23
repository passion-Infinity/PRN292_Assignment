using BusinessObjects.BusinessRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class User : BusinessObject
    {
        public User()
        {
            AddRule(new ValidateRequired("UserID"));
            AddRule(new ValidateLength("UserID", 1, 100));

            AddRule(new ValidateRequired("FullName"));
            AddRule(new ValidateLength("FullName", 1, 50));

            AddRule(new ValidateRequired("Password"));
            AddRule(new ValidateLength("Password", 1, 50));

            AddRule(new ValidateRequired("Phone"));
            AddRule(new ValidatePhone("Phone"));

            AddRule(new ValidateRequired("Email"));
            AddRule(new ValidateEmail("Email"));

            AddRule(new ValidateRequired("IdentityCard"));
            AddRule(new ValidateIdentity("IdentityCard"));

            AddRule(new ValidateRequired("Address"));
            AddRule(new ValidateLength("Address", 1, 200));
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
