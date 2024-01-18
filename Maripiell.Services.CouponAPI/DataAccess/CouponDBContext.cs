using Maripiell.Services.CouponAPI.Domain.Contracts;
using Maripiell.Services.CouponAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Maripiell.Services.CouponAPI.DataAccess
{
    public class CouponDBContext : DbContext
    {
        public CouponDBContext(DbContextOptions<CouponDBContext> options): base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        #region Save Changes
        public override int SaveChanges()
        {
            var auditableEntitySet = ChangeTracker.Entries<IAudityEntity>();

            if (auditableEntitySet != null)
            {
                foreach (var auditableEntity in auditableEntitySet.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified))
                {
                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreatedDate = DateTime.Now;
                        auditableEntity.Entity.CreatedBy = 1;
                    }

                    auditableEntity.Entity.UpdatedDate = DateTime.Now;
                    auditableEntity.Entity.UpdatedBy = 1;
                }
            }

            return base.SaveChanges();
        }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var coupons = modelBuilder.Entity<Coupon>();

            var defaultCoupons = new List<Coupon>()
            {
                new("10OFF", 0.1, 5000) { Id = 1, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
                new("20OFF", 0.2, 10000) { Id = 2, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
                new("30OFF", 0.3, 15000) { Id = 3, CreatedBy = 1, UpdatedBy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now}
            };

            coupons.HasData(defaultCoupons);
        }
    }
}
