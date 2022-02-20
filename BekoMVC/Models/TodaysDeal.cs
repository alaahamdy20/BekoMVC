using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class TodaysDeal
    {
        public TodaysDeal()
        {
            TodaysDealsProducts = new HashSet<TodaysDealsProduct>();
        }

        public int DealId { get; set; }
        public int DealAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string AdminUsername { get; set; }

        public virtual Admin AdminUsernameNavigation { get; set; }
        public virtual ICollection<TodaysDealsProduct> TodaysDealsProducts { get; set; }
    }
}
