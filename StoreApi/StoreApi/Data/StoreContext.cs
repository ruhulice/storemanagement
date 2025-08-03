using Microsoft.EntityFrameworkCore;
using StoreApi.Models;

namespace StoreApi.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        // Add model class for DB table creation
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<DocumentType> documentTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApprovalTemplate> ApprovalTemplates { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionDetails> RequisitionDetails { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ApprovalPath> ApprovalPaths { get; set; }
        public DbSet<ApprovalPathDetails> ApprovalPathDetails { get; set; }
        public DbSet<ApprovalFlow> ApprovalFlows { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasOne(p => p.SubCategory).WithMany().HasForeignKey(p => p.SubCategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SubCategory>().HasOne(s => s.Category).WithMany().HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Stock>().HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasOne(v => v.Vendor).WithMany().HasForeignKey(v => v.VendorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrder>().HasOne(v => v.Tender).WithMany().HasForeignKey(v => v.TenderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrderDetails>().HasOne(p => p.PurchaseOrder).WithMany().HasForeignKey(p => p.PurchaseOrderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PurchaseOrderDetails>().HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Requisition>().HasOne(p => p.Employee).WithMany().HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Requisition>().HasOne(p => p.Status).WithMany().HasForeignKey(p => p.StatusId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RequisitionDetails>().HasOne(p => p.Requisition).WithMany().HasForeignKey(p => p.RequisitionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RequisitionDetails>().HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Issue>().HasOne(p => p.Requisition).WithMany().HasForeignKey(p => p.RequisitionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Issue>().HasOne(p => p.Employee).WithMany().HasForeignKey(p => p.IssuedToId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaction>().HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaction>().HasOne(p => p.DocumentType).WithMany().HasForeignKey(p => p.TransactionTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasOne(u => u.Division).WithMany().HasForeignKey(u => u.DivisionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Employee>().HasOne(u => u.Designation).WithMany().HasForeignKey(u => u.DivisionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalPath>().HasOne(a => a.DocumentType).WithMany().HasForeignKey(a => a.DocumentTypeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalPath>().HasOne(a => a.ApprovalTemplate).WithMany().HasForeignKey(a => a.ApprovalTemplateId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalPathDetails>().HasOne(p => p.ApprovalPath).WithMany().HasForeignKey(p => p.ApprovalPathId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalPathDetails>().HasOne(p => p.Employee).WithMany().HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalPathDetails>().HasOne(p => p.Status).WithMany().HasForeignKey(p => p.StatusId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalFlow>().HasOne(f => f.DocumentType).WithMany().HasForeignKey(f => f.DocumentId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ApprovalFlow>().HasOne(f => f.ApprovalPath).WithMany().HasForeignKey(f => f.ApprovalPathId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(r => r.Employee).WithMany().HasForeignKey(r => r.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>().HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserRole>().HasOne(r => r.Role).WithMany().HasForeignKey(r => r.RoleId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
