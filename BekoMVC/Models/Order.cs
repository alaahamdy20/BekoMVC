using System;
using System.Collections.Generic;

#nullable disable

namespace BekoMVC.Models
{
    public partial class Order
    {
        public Order()
        {
            AdminDeliveryOrders = new HashSet<AdminDeliveryOrder>();
            CustomerAddstoCartProducts = new HashSet<CustomerAddstoCartProduct>();
            Products = new HashSet<Product>();
        }

        public int OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? CashAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string PaymentType { get; set; }
        public string OrderStatus { get; set; }
        public int? RemainingDays { get; set; }
        public int? TimeLimit { get; set; }
        public string GiftCardCodeUsed { get; set; }
        public string CustomerName { get; set; }
        public int? DeliveryId { get; set; }
        public string CreditCardNumber { get; set; }

        public virtual CreditCard CreditCardNumberNavigation { get; set; }
        public virtual Customer CustomerNameNavigation { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual Giftcard GiftCardCodeUsedNavigation { get; set; }
        public virtual ICollection<AdminDeliveryOrder> AdminDeliveryOrders { get; set; }
        public virtual ICollection<CustomerAddstoCartProduct> CustomerAddstoCartProducts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
