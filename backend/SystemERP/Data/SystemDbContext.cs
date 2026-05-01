using Microsoft.EntityFrameworkCore;
using Entities.Security;
using Entities.HumanResources;
using Entities.Inventory;
using Entities.Sales;
using Entities.Purchases;
using Entities.Finances;

namespace Data
{
    public class SystemDbContext:DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options):base(options) {}

        #region Security
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        #endregion

        #region HumanResources
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeePositionHistory> EmployeePositionHistory { get; set; }
        #endregion

        #region Inventory
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductPresentation> ProductPresentations { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }
        public DbSet<InventoryMovementReason> InventoryMovementReasons { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        #endregion

        #region Sales
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHeader> SaleHeaders { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SalePaymentDetail> SalePaymentDetails { get; set; }
        #endregion

        #region Purchases
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseHeader> PurchaseHeaders { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchasePaymentDetail> PurchasePaymentDetails { get; set; }
        #endregion

        #region Finances
        public DbSet<PaymentForm> PaymentForms { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Security
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Security");
                entity.Property(p => p.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(p => p.Email).IsUnique();
                entity.Property(p => p.PasswordHash).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Security");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AuditLog", "Security", t => t.HasCheckConstraint("CK_AuditLog_Values", "[OldValues] IS NOT NULL OR [NewValues] IS NOT NULL"));
                entity.Property(p => p.EntityName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.EntityId).IsRequired();
                entity.Property(p => p.Action).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module", "Security");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(30);
                entity.Property(p => p.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission", "Security");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(30);
            });

            modelBuilder.Entity<UserRole>().ToTable("UserRole", "Security");
            modelBuilder.Entity<RolePermission>().ToTable("RolePermission", "Security");
            #endregion

            #region HumanResources
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "HumanResources");
                entity.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.LastName).IsRequired().HasMaxLength(50);
                entity.Property(p => p.DocumentNumber).IsRequired().HasMaxLength(20);
                entity.HasIndex(p => p.DocumentNumber).IsUnique();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "HumanResources");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position", "HumanResources");
                entity.Property(p => p.Title).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<EmployeePositionHistory>(entity =>
            {
                entity.ToTable("EmployeePositionHistory", "HumanResources");
                entity.Property(p => p.StartDate).IsRequired();
            });
            #endregion

            #region Inventory
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "Inventory");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(255);
                entity.Property(p => p.BaseSKU).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.BaseSKU).IsUnique();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "Inventory");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Name).IsUnique();
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse", "Inventory");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.Property(p => p.Location).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<ProductPresentation>(entity =>
            {
                entity.ToTable("ProductPresentation", "Inventory");
                entity.Property(p => p.PresentationSKU).IsRequired().HasMaxLength(100);
                entity.HasIndex(p => p.PresentationSKU).IsUnique();
                entity.Property(p => p.Barcode).IsRequired().HasMaxLength(100);
                entity.HasIndex(p => p.Barcode).IsUnique();
                entity.Property(p => p.Price).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.ConversionFactor).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.IsBaseUnit).IsRequired();
            });

            modelBuilder.Entity<ProductStock>(entity =>
            {
                entity.ToTable("ProductStock", "Inventory");
                entity.Property(p => p.Quantity).IsRequired().HasPrecision(18, 5);
            });

            modelBuilder.Entity<InventoryMovement>(entity =>
            {
                entity.ToTable("InventoryMovement", "Inventory");
                entity.Property(p => p.Quantity).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.Observation).HasMaxLength(255);
            });

            modelBuilder.Entity<InventoryMovementReason>(entity =>
            {
                entity.ToTable("InventoryMovementReason", "Inventory");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.Property(p => p.ActionType).IsRequired();
            });
            
            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.ToTable("UnitOfMeasure", "Inventory");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.Property(p => p.Description).HasMaxLength(255);
                entity.Property(p => p.Abbreviation).IsRequired().HasMaxLength(10);
                entity.HasIndex(p => p.Abbreviation).IsUnique();
                entity.Property(p => p.IsActive).IsRequired();
            });
            #endregion

            #region Sales
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Sales");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.DocumentNumber).IsRequired().HasMaxLength(20);
                entity.HasIndex(p => p.DocumentNumber).IsUnique();
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.PhoneNumber).HasMaxLength(20);
                entity.Property(p => p.Address).HasMaxLength(255);
                entity.Property(p => p.IsActive).IsRequired();
            });

            modelBuilder.Entity<SaleHeader>(entity =>
            {
                entity.ToTable("SaleHeader", "Sales");
                entity.Property(p => p.InvoiceNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.InvoiceNumber).IsUnique();
                entity.Property(p => p.SaleDate).IsRequired();
                entity.Property(p => p.SubTotal).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.TaxAmount).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.Total).IsRequired().HasPrecision(18, 5);
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.ToTable("SaleDetail", "Sales");
                entity.Property(p => p.Quantity).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.UnitPrice).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.TaxAmount).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.Total).IsRequired().HasPrecision(18, 5);
            });

            modelBuilder.Entity<SalePaymentDetail>(entity =>
            {
                entity.ToTable("SalePaymentDetail", "Sales");
                entity.Property(p => p.Amount).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.Reference).HasMaxLength(100);
            });
            #endregion

            #region Purchases
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier", "Purchases");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.TaxId).IsRequired().HasMaxLength(20);
                entity.HasIndex(p => p.TaxId).IsUnique();
                entity.Property(p => p.ContactName).HasMaxLength(100);
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.PhoneNumber).HasMaxLength(20);
                entity.Property(p => p.Address).HasMaxLength(255);
                entity.Property(p => p.IsActive).IsRequired();
            });

            modelBuilder.Entity<PurchaseHeader>(entity =>
            {
                entity.ToTable("PurchaseHeader", "Purchases");
                entity.Property(p => p.InvoiceNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.InvoiceNumber).IsUnique();
                entity.Property(p => p.PurchaseDate).IsRequired();
                entity.Property(p => p.Total).IsRequired().HasPrecision(18, 5);
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.ToTable("PurchaseDetail", "Purchases");
                entity.Property(p => p.Quantity).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.UnitCost).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.Total).IsRequired().HasPrecision(18, 5);
            });

            modelBuilder.Entity<PurchasePaymentDetail>(entity =>
            {
                entity.ToTable("PurchasePaymentDetail", "Purchases");
                entity.Property(p => p.Amount).IsRequired().HasPrecision(18, 5);
                entity.Property(p => p.Reference).HasMaxLength(100);
            });
            #endregion

            #region Finances
            modelBuilder.Entity<PaymentForm>(entity =>
            {
                entity.ToTable("PaymentForm", "Finances");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.Property(p => p.DaysToPay).IsRequired();
                entity.Property(p => p.IsActive).IsRequired();
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod", "Finances");
                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
                entity.HasIndex(p => p.Name).IsUnique();
                entity.Property(p => p.Code).HasMaxLength(20);
                entity.Property(p => p.IsActive).IsRequired();
            });
            #endregion
        }
    }
}
