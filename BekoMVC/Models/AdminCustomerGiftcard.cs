using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class AdminCustomerGiftcard
    {
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public string AdminUsername { get; set; }
        public int? RemainingPoints { get; set; }

        public virtual Admin AdminUsernameNavigation { get; set; }
        public virtual Giftcard CodeNavigation { get; set; }
        public virtual Customer CustomerNameNavigation { get; set; }
    }
}
