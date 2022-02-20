using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class WishlistProduct
    {
        public string Username { get; set; }
        public string WishName { get; set; }
        public int SerialNo { get; set; }

        public virtual Product SerialNoNavigation { get; set; }
        public virtual Wishlist Wishlist { get; set; }
    }
}
