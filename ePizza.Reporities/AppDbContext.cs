using System;

using ePizzaHub.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizza.Repositories
{
    public class AppDbContext:IdentityDbContext<User,Role,int>
    {
        public AppDbContext()
        {
             
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<ItemType> itemTypes { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<PaymentDetails> paymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local)\\AAVASH;Database=ePizza;Trusted_Connection=True;Integrated Security=True;User Id=sa;Password=imatesp3;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
