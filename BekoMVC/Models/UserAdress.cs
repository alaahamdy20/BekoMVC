using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class UserAdress
    {
        public string Address { get; set; }
        public string Username { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
