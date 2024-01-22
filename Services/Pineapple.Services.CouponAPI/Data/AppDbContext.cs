using Microsoft.EntityFrameworkCore;
using Pineapple.Services.CouponAPI.Models;

namespace Pineapple.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "5OFF",
                DiscountAmount = 5,
                MinimalAmount = 10 
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinimalAmount = 30
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinimalAmount = 500
            });
        }
    }
}
