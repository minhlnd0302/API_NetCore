using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Models
{
    public partial class TGDDContext : DbContext
    {
        public TGDDContext()
        {
        }

        public TGDDContext(DbContextOptions<TGDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<UseVoucher> UseVouchers { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:minhlnd.database.windows.net,1433;Initial Catalog=TGDD;Persist Security Info=False;User ID=minhlnd;Password=3223minh!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_Admins_Roles");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Carts_Customers");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.ToTable("Cart_Details");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_CartDetails_Carts");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Comments_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Comments_Products");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsReply).HasColumnName("Is_Reply");

                entity.Property(e => e.Message).HasColumnType("ntext");

                entity.Property(e => e.Phone)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname).HasMaxLength(200);

                entity.Property(e => e.Lastname).HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_Customers_Roles");
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Battery).HasMaxLength(200);

                entity.Property(e => e.Color).HasMaxLength(200);

                entity.Property(e => e.Cpu)
                    .HasMaxLength(200)
                    .HasColumnName("CPU");

                entity.Property(e => e.Introduction).HasColumnName("introduction");

                entity.Property(e => e.Memory).HasMaxLength(200);

                entity.Property(e => e.Os)
                    .HasMaxLength(200)
                    .HasColumnName("OS");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Ram).HasMaxLength(200);

                entity.Property(e => e.ScreenSize).HasMaxLength(200);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Descriptions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Description_Products");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.IsFavorited).HasColumnName("Is_favorited");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Favorites_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Favorites_Products");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(200)
                    .HasColumnName("Payment_method");

                entity.Property(e => e.ShippingAdress).HasMaxLength(200);

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.Total).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Orders_Status");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Details");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BrandId).HasColumnName("Brand_Id");

                entity.Property(e => e.BuyingTimes).HasColumnName("Buying_times");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.DateArrive)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Date_arrive");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Products_Brands");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<UseVoucher>(entity =>
            {
                entity.ToTable("UseVoucher");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.VoucherId).HasColumnName("Voucher_Id");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.UseVouchers)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_UseVoucher_Vouchers");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
