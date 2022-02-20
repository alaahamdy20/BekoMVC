using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class AdminDeliveryOrder
    {
        public string DeliveryUsername { get; set; }
        public int OrderNo { get; set; }
        public string AdminUsername { get; set; }
        public string DeliveryWindow { get; set; }

        public virtual Admin AdminUsernameNavigation { get; set; }
        public virtual DeliveryPersonel DeliveryUsernameNavigation { get; set; }
        public virtual Order OrderNoNavigation { get; set; }
    }
}
