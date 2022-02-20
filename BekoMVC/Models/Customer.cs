using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            AdminCustomerGiftcards = new HashSet<AdminCustomerGiftcard>();
            CustomerAddstoCartProducts = new HashSet<CustomerAddstoCartProduct>();
            CustomerCreditCards = new HashSet<CustomerCreditCard>();
            CustomerQuestionProducts = new HashSet<CustomerQuestionProduct>();
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            Wishlists = new HashSet<Wishlist>();
        }

        public string Username { get; set; }
        public int? Points { get; set; }

        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<AdminCustomerGiftcard> AdminCustomerGiftcards { get; set; }
        public virtual ICollection<CustomerAddstoCartProduct> CustomerAddstoCartProducts { get; set; }
        public virtual ICollection<CustomerCreditCard> CustomerCreditCards { get; set; }
        public virtual ICollection<CustomerQuestionProduct> CustomerQuestionProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
