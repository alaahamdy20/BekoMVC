using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class TodaysDealsProduct
    {
        public int DealId { get; set; }
        public int SerialNo { get; set; }

        public virtual TodaysDeal Deal { get; set; }
        public virtual Product SerialNoNavigation { get; set; }
    }
}
