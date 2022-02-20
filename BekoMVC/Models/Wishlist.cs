using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Wishlist
    {
        public Wishlist()
        {
            WishlistProducts = new HashSet<WishlistProduct>();
        }

        public string Username { get; set; }
        public string Name { get; set; }

        public virtual Customer UsernameNavigation { get; set; }
        public virtual ICollection<WishlistProduct> WishlistProducts { get; set; }
    }
}
