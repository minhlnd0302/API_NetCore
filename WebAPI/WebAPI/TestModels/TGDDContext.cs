using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.TestModels
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

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<CartDetails> CartDetails { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Circle> Circle { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DayStatisticals> DayStatisticals { get; set; }
        public virtual DbSet<Descriptions> Descriptions { get; set; }
        public virtual DbSet<Favorite> Favorite { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<MonthStatisticals> MonthStatisticals { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TopCustomers> TopCustomers { get; set; }
        public virtual DbSet<TopProducts> TopProducts { get; set; }
        public virtual DbSet<UseVoucher> UseVoucher { get; set; }
        public virtual DbSet<Vouchers> Vouchers { get; set; }
        public virtual DbSet<WeekStatisticals> WeekStatisticals { get; set; }
        public virtual DbSet<YearStatisticals> YearStatisticals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:minhlnd.database.windows.net,1433;Initial Catalog=TGDD;Persist Security Info=False;User ID=minhlnd;Password=3223minh!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
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

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Country).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<CartDetails>(entity =>
            {
                entity.ToTable("Cart_Details");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CartId).HasColumnName("Cart_Id");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_CartDetails_Carts");
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Carts_Customers");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Circle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Circle)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Circle_Categories");
            });

            modelBuilder.Entity<Comments>(entity =>
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

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Message).HasMaxLength(300);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

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

            modelBuilder.Entity<DayStatisticals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TotalDay).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.DayStatisticals)
                    .HasForeignKey(d => d.MonthId)
                    .HasConstraintName("FK_DayStatisticals_MonthStatisticals");

                entity.HasOne(d => d.Week)
                    .WithMany(p => p.DayStatisticals)
                    .HasForeignKey(d => d.WeekId)
                    .HasConstraintName("FK_DayStatisticals_WeekStatisticals");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.DayStatisticals)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_DayStatisticals_YearStatisticals");
            });

            modelBuilder.Entity<Descriptions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Battery).HasMaxLength(200);

                entity.Property(e => e.Color).HasMaxLength(200);

                entity.Property(e => e.Cpu)
                    .HasColumnName("CPU")
                    .HasMaxLength(200);

                entity.Property(e => e.Introduction).HasColumnName("introduction");

                entity.Property(e => e.Memory).HasMaxLength(200);

                entity.Property(e => e.Os)
                    .HasColumnName("OS")
                    .HasMaxLength(200);

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

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Favorite)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Favorite_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Favorite)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Favorite_Products");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<MonthStatisticals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TotalMonth).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.MonthStatisticals)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_MonthStatisticals_YearStatisticals");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("Order_Details");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CurrentPrice).HasColumnType("decimal(19, 2)");

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

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PaymentMethod).HasMaxLength(200);

                entity.Property(e => e.ShippingAddress).HasMaxLength(200);

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

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BrandId).HasColumnName("Brand_Id");

                entity.Property(e => e.BuyingTimes).HasColumnName("Buying_times");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.DateArrive)
                    .HasColumnName("Date_arrive")
                    .HasMaxLength(200)
                    .IsUnicode(false);

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

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TopCustomers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastBuy).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TopCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_TopCustomers_Customers");
            });

            modelBuilder.Entity<TopProducts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TopProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_TopProducts_Products");
            });

            modelBuilder.Entity<UseVoucher>(entity =>
            {
                entity.Property(e => e.ID)
                    .HasColumnName("iD")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.UseVoucher)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_UseVoucher_Vouchers");
            });

            modelBuilder.Entity<Vouchers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WeekStatisticals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TotalWeek).HasColumnType("decimal(19, 2)");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.WeekStatisticals)
                    .HasForeignKey(d => d.MonthId)
                    .HasConstraintName("FK_WeekStatisticals_MonthStatisticals");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.WeekStatisticals)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_WeekStatisticals_YearStatisticals");
            });

            modelBuilder.Entity<YearStatisticals>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TotalYear).HasColumnType("decimal(19, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
