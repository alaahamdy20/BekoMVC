using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Product
    {
        public Product()
        {
            CustomerQuestionProducts = new HashSet<CustomerQuestionProduct>();
            OffersOnProducts = new HashSet<OffersOnProduct>();
            ProductColors = new HashSet<ProductColor>();
            TodaysDealsProducts = new HashSet<TodaysDealsProduct>();
            WishlistProducts = new HashSet<WishlistProduct>();
        }

        public int SerialNo { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? FinalPrice { get; set; }
        public string Color { get; set; }
        public bool? Available { get; set; }
        public int? Rate { get; set; }
        public string VendorUsername { get; set; }
        public string CustomerUsername { get; set; }
        public int? CustomerOrderId { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string Subcategory { get; set; }

        public virtual Order CustomerOrder { get; set; }
        public virtual Customer CustomerUsernameNavigation { get; set; }
        public virtual Vendor VendorUsernameNavigation { get; set; }
        public virtual ICollection<CustomerQuestionProduct> CustomerQuestionProducts { get; set; }
        public virtual ICollection<OffersOnProduct> OffersOnProducts { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<TodaysDealsProduct> TodaysDealsProducts { get; set; }
        public virtual ICollection<WishlistProduct> WishlistProducts { get; set; }
    }
}
