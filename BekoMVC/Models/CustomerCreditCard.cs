using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class CustomerCreditCard
    {
        public string CustomerName { get; set; }
        public string CcNumber { get; set; }

        public virtual CreditCard CcNumberNavigation { get; set; }
        public virtual Customer CustomerNameNavigation { get; set; }
    }
}
