using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Admin
    {
        public Admin()
        {
            AdminCustomerGiftcards = new HashSet<AdminCustomerGiftcard>();
            AdminDeliveryOrders = new HashSet<AdminDeliveryOrder>();
            Deliveries = new HashSet<Delivery>();
            Giftcards = new HashSet<Giftcard>();
            TodaysDeals = new HashSet<TodaysDeal>();
            Vendors = new HashSet<Vendor>();
        }

        public string Username { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<AdminCustomerGiftcard> AdminCustomerGiftcards { get; set; }
        public virtual ICollection<AdminDeliveryOrder> AdminDeliveryOrders { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Giftcard> Giftcards { get; set; }
        public virtual ICollection<TodaysDeal> TodaysDeals { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
