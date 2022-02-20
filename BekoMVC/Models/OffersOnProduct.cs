using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class OffersOnProduct
    {
        public int OfferId { get; set; }
        public int SerialNo { get; set; }

        public virtual Offer Offer { get; set; }
        public virtual Product SerialNoNavigation { get; set; }
    }
}
