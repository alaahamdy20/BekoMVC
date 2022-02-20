using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class DeliveryPersonel
    {
        public DeliveryPersonel()
        {
            AdminDeliveryOrders = new HashSet<AdminDeliveryOrder>();
        }

        public string Username { get; set; }
        public bool? IsActivated { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<AdminDeliveryOrder> AdminDeliveryOrders { get; set; }
    }
}
