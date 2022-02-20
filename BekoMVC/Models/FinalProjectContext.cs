using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BekoMVC.Models
{
    public partial class FinalProjectContext : DbContext
    {
        public FinalProjectContext()
        {
        }

        public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminCustomerGiftcard> AdminCustomerGiftcards { get; set; }
        public virtual DbSet<AdminDeliveryOrder> AdminDeliveryOrders { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddstoCartProduct> CustomerAddstoCartProducts { get; set; }
        public virtual DbSet<CustomerCreditCard> CustomerCreditCards { get; set; }
        public virtual DbSet<CustomerQuestionProduct> CustomerQuestionProducts { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<DeliveryPersonel> DeliveryPersonels { get; set; }
        public virtual DbSet<Giftcard> Giftcards { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OffersOnProduct> OffersOnProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<TodaysDeal> TodaysDeals { get; set; }
        public virtual DbSet<TodaysDealsProduct> TodaysDealsProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAdress> UserAdresses { get; set; }
        public virtual DbSet<UserMobileNumber> UserMobileNumbers { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
        public virtual DbSet<WishlistProduct> WishlistProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=FinalProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pr_admin");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Username)
                    .HasConstraintName("fr_username_admins");
            });

            modelBuilder.Entity<AdminCustomerGiftcard>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.CustomerName, e.AdminUsername })
                    .HasName("pr_admin_customer_giftcard");

                entity.ToTable("Admin_Customer_Giftcard");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.AdminUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("admin_username");

                entity.Property(e => e.RemainingPoints).HasColumnName("remaining_points");

                entity.HasOne(d => d.AdminUsernameNavigation)
                    .WithMany(p => p.AdminCustomerGiftcards)
                    .HasForeignKey(d => d.AdminUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fl_admin_username_giftcard");

                entity.HasOne(d => d.CodeNavigation)
                    .WithMany(p => p.AdminCustomerGiftcards)
                    .HasForeignKey(d => d.Code)
                    .HasConstraintName("fr_code_giftcard");

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.AdminCustomerGiftcards)
                    .HasForeignKey(d => d.CustomerName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_customer_name_giftcard");
            });

            modelBuilder.Entity<AdminDeliveryOrder>(entity =>
            {
                entity.HasKey(e => new { e.DeliveryUsername, e.OrderNo })
                    .HasName("pr_admin_delivery_order");

                entity.ToTable("Admin_Delivery_Order");

                entity.Property(e => e.DeliveryUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("delivery_username");

                entity.Property(e => e.OrderNo).HasColumnName("order_no");

                entity.Property(e => e.AdminUsername)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("admin_username");

                entity.Property(e => e.DeliveryWindow)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("delivery_window");

                entity.HasOne(d => d.AdminUsernameNavigation)
                    .WithMany(p => p.AdminDeliveryOrders)
                    .HasForeignKey(d => d.AdminUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_admin_username_delivery");

                entity.HasOne(d => d.DeliveryUsernameNavigation)
                    .WithMany(p => p.AdminDeliveryOrders)
                    .HasForeignKey(d => d.DeliveryUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_delivery_username_order");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.AdminDeliveryOrders)
                    .HasForeignKey(d => d.OrderNo)
                    .HasConstraintName("fr_order_no_delivery");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("pr_cc");

                entity.ToTable("Credit_Card");

                entity.Property(e => e.Number)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("number");

                entity.Property(e => e.CvvCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cvv_code");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiry_date");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pr_customer");

                entity.ToTable("Customer");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Username)
                    .HasConstraintName("fr_username_customer");
            });

            modelBuilder.Entity<CustomerAddstoCartProduct>(entity =>
            {
                entity.HasKey(e => new { e.SerialNo, e.CustomerName })
                    .HasName("pr_custaddscart");

                entity.ToTable("CustomerAddstoCartProduct");

                entity.Property(e => e.SerialNo).HasColumnName("serial_no");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.CustomerAddstoCartProducts)
                    .HasForeignKey(d => d.CustomerName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_c_name");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.CustomerAddstoCartProducts)
                    .HasForeignKey(d => d.SerialNo)
                    .HasConstraintName("fr_serial_no");
            });

            modelBuilder.Entity<CustomerCreditCard>(entity =>
            {
                entity.HasKey(e => new { e.CustomerName, e.CcNumber })
                    .HasName("pr_customer_creditcard");

                entity.ToTable("Customer_CreditCard");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CcNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cc_number");

                entity.HasOne(d => d.CcNumberNavigation)
                    .WithMany(p => p.CustomerCreditCards)
                    .HasForeignKey(d => d.CcNumber)
                    .HasConstraintName("fr_cc_number");

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.CustomerCreditCards)
                    .HasForeignKey(d => d.CustomerName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_customer_name_cc");
            });

            modelBuilder.Entity<CustomerQuestionProduct>(entity =>
            {
                entity.HasKey(e => new { e.SerialNo, e.CustomerName })
                    .HasName("pr_custquesprod");

                entity.ToTable("Customer_Question_Product");

                entity.Property(e => e.SerialNo).HasColumnName("serial_no");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Answer)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("answer");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("question");

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.CustomerQuestionProducts)
                    .HasForeignKey(d => d.CustomerName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_customer_name");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.CustomerQuestionProducts)
                    .HasForeignKey(d => d.SerialNo)
                    .HasConstraintName("fr_serial_no_cart");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fees)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("fees");

                entity.Property(e => e.TimeDuration).HasColumnName("time_duration");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fr_usrAdmin");
            });

            modelBuilder.Entity<DeliveryPersonel>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pr_delivery_personel");

                entity.ToTable("Delivery_personel");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.IsActivated)
                    .HasColumnName("is_activated")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.DeliveryPersonel)
                    .HasForeignKey<DeliveryPersonel>(d => d.Username)
                    .HasConstraintName("fr_username_delivery");
            });

            modelBuilder.Entity<Giftcard>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("pr_Giftcard");

                entity.ToTable("Giftcard");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Giftcards)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_username_wishlist_customer");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("offer");

                entity.Property(e => e.OfferId).HasColumnName("offer_id");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.OfferAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("offer_amount");
            });

            modelBuilder.Entity<OffersOnProduct>(entity =>
            {
                entity.HasKey(e => new { e.OfferId, e.SerialNo })
                    .HasName("pr_offersprod");

                entity.ToTable("offersOnProduct");

                entity.Property(e => e.OfferId).HasColumnName("offer_id");

                entity.Property(e => e.SerialNo).HasColumnName("serial_no");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.OffersOnProducts)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("fr_offer_id");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.OffersOnProducts)
                    .HasForeignKey(d => d.SerialNo)
                    .HasConstraintName("fr_serial_prod");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("pr_orders");

                entity.Property(e => e.OrderNo).HasColumnName("order_no");

                entity.Property(e => e.CashAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("cash_amount");

                entity.Property(e => e.CreditAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("credit_amount");

                entity.Property(e => e.CreditCardNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("creditCard_number");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");

                entity.Property(e => e.GiftCardCodeUsed)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Gift_Card_code_used");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("order_status")
                    .HasDefaultValueSql("('NOT PROCESSED')");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("payment_type");

                entity.Property(e => e.RemainingDays).HasColumnName("remaining_days");

                entity.Property(e => e.TimeLimit).HasColumnName("time_limit");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_amount");

                entity.HasOne(d => d.CreditCardNumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CreditCardNumber)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fr_cc_num");

                entity.HasOne(d => d.CustomerNameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerName)
                    .HasConstraintName("fr_name");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryId)
                    .HasConstraintName("fr_D_id");

                entity.HasOne(d => d.GiftCardCodeUsedNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.GiftCardCodeUsed)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fr_gf_code");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("pr_product");

                entity.ToTable("Product");

                entity.Property(e => e.SerialNo).HasColumnName("serial_no");

                entity.Property(e => e.Available)
                    .HasColumnName("available")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Brand)
                    .HasMaxLength(10)
                    .HasColumnName("brand")
                    .IsFixedLength(true);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.CustomerOrderId).HasColumnName("customer_order_id");

                entity.Property(e => e.CustomerUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customer_username");

                entity.Property(e => e.FinalPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("final_price");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductDescription)
                    .HasColumnType("text")
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.Rate).HasColumnName("rate");

                entity.Property(e => e.Subcategory)
                    .HasMaxLength(20)
                    .HasColumnName("subcategory");

                entity.Property(e => e.VendorUsername)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vendor_username");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fr_co_id");

                entity.HasOne(d => d.CustomerUsernameNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CustomerUsername)
                    .HasConstraintName("fr_c_usr");

                entity.HasOne(d => d.VendorUsernameNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorUsername)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_v_usr");
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.Color });

                entity.ToTable("product_colors");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Img1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("img1");

                entity.Property(e => e.Img2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("img2");

                entity.Property(e => e.Img3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("img3");

                entity.Property(e => e.Img4)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("img4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_colors_Product");
            });

            modelBuilder.Entity<TodaysDeal>(entity =>
            {
                entity.HasKey(e => e.DealId)
                    .HasName("pr_todays_deal");

                entity.ToTable("Todays_Deals");

                entity.Property(e => e.DealId).HasColumnName("deal_id");

                entity.Property(e => e.AdminUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("admin_username");

                entity.Property(e => e.DealAmount).HasColumnName("deal_amount");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiry_date");

                entity.HasOne(d => d.AdminUsernameNavigation)
                    .WithMany(p => p.TodaysDeals)
                    .HasForeignKey(d => d.AdminUsername)
                    .HasConstraintName("fr_admin_todays_deal");
            });

            modelBuilder.Entity<TodaysDealsProduct>(entity =>
            {
                entity.HasKey(e => new { e.DealId, e.SerialNo })
                    .HasName("pr_todays_deal_prod");

                entity.ToTable("Todays_Deals_Product");

                entity.Property(e => e.DealId).HasColumnName("deal_id");

                entity.Property(e => e.SerialNo).HasColumnName("serial_no");

                entity.HasOne(d => d.Deal)
                    .WithMany(p => p.TodaysDealsProducts)
                    .HasForeignKey(d => d.DealId)
                    .HasConstraintName("fr_deal_id");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.TodaysDealsProducts)
                    .HasForeignKey(d => d.SerialNo)
                    .HasConstraintName("fr_seriall_deal");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pr_users");

                entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646776BD3C")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UserAdress>(entity =>
            {
                entity.HasKey(e => new { e.Address, e.Username })
                    .HasName("pr_addresses");

                entity.ToTable("User_Adresses");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserAdresses)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fr_username_adresses");
            });

            modelBuilder.Entity<UserMobileNumber>(entity =>
            {
                entity.HasKey(e => new { e.MobileNumber, e.Username })
                    .HasName("pr_mobile_numbers");

                entity.ToTable("User_mobile_numbers");

                entity.HasIndex(e => e.MobileNumber, "UQ__User_mob__30462B0F2F8B82CC")
                    .IsUnique();

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("mobile_number");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.UserMobileNumbers)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("fr_username_mobiles");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pr_vendor");

                entity.ToTable("Vendor");

                entity.HasIndex(e => e.BankAccNo, "UQ__Vendor__122233930E441473")
                    .IsUnique();

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Activated)
                    .HasColumnName("activated")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AdminUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("admin_username");

                entity.Property(e => e.BankAccNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bank_acc_no");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.HasOne(d => d.AdminUsernameNavigation)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.AdminUsername)
                    .HasConstraintName("fr_admin");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Vendor)
                    .HasForeignKey<Vendor>(d => d.Username)
                    .HasConstraintName("fr_username_vendor");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.Name })
                    .HasName("pr_wishlist");

                entity.ToTable("Wishlist");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fr_user_name");
            });

            modelBuilder.Entity<WishlistProduct>(entity =>
            {
                entity.HasKey(e => new { e.Username, e.WishName, e.SerialNo })
                    .HasName("pr_wishlist_prod");

                entity.ToTable("Wishlist_Product");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.WishName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("wish_name");

                entity.Property(e => e.SerialNo).HasColumnName("serial_no");

                entity.HasOne(d => d.SerialNoNavigation)
                    .WithMany(p => p.WishlistProducts)
                    .HasForeignKey(d => d.SerialNo)
                    .HasConstraintName("fr_serial_no_product_wishlist");

                entity.HasOne(d => d.Wishlist)
                    .WithMany(p => p.WishlistProducts)
                    .HasForeignKey(d => new { d.Username, d.WishName })
                    .HasConstraintName("fr_username_wishlist");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
