using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace angular2_asp.Models
{
    public class ApiContext: DbContext
    {
        //public class ApplicationUser : IdentityUser { }
        public ApiContext(DbContextOptions<ApiContext> options) :base(options){}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }   
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            // set composite key with fluent api                
            modelBuilder.Entity<OrderDetail>()
                .HasKey(table => new {table.OrderID, table.ProductID});
                
        }
    }
}