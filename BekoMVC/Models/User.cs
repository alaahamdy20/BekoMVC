using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class User
    {
        public User()
        {
            UserAdresses = new HashSet<UserAdress>();
            UserMobileNumbers = new HashSet<UserMobileNumber>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DeliveryPersonel DeliveryPersonel { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<UserAdress> UserAdresses { get; set; }
        public virtual ICollection<UserMobileNumber> UserMobileNumbers { get; set; }
    }
}
