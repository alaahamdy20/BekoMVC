using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Giftcard
    {
        public Giftcard()
        {
            AdminCustomerGiftcards = new HashSet<AdminCustomerGiftcard>();
            Orders = new HashSet<Order>();
        }

        public string Code { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }

        public virtual Admin UsernameNavigation { get; set; }
        public virtual ICollection<AdminCustomerGiftcard> AdminCustomerGiftcards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
