using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            CustomerCreditCards = new HashSet<CustomerCreditCard>();
            Orders = new HashSet<Order>();
        }

        public string Number { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CvvCode { get; set; }

        public virtual ICollection<CustomerCreditCard> CustomerCreditCards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
