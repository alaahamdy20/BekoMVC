using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Products = new HashSet<Product>();
        }

        public string Username { get; set; }
        public bool? Activated { get; set; }
        public string CompanyName { get; set; }
        public string BankAccNo { get; set; }
        public string AdminUsername { get; set; }

        public virtual Admin AdminUsernameNavigation { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
