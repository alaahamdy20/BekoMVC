using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Offer
    {
        public Offer()
        {
            OffersOnProducts = new HashSet<OffersOnProduct>();
        }

        public int OfferId { get; set; }
        public decimal OfferAmount { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual ICollection<OffersOnProduct> OffersOnProducts { get; set; }
    }
}
