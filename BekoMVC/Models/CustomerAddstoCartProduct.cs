using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class CustomerAddstoCartProduct
    {
        public int SerialNo { get; set; }
        public string CustomerName { get; set; }
        public int? Quantity { get; set; }

        public virtual Customer CustomerNameNavigation { get; set; }
        public virtual Order SerialNoNavigation { get; set; }
    }
}
