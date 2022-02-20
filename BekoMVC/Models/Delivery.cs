using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public int? TimeDuration { get; set; }
        public decimal? Fees { get; set; }
        public string Username { get; set; }

        public virtual Admin UsernameNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
