using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Yumyum.Data.Models;

namespace Yumyum.Data
{
    public class YumyumDbContext : IdentityDbContext<ApplicationUser>
    {
        public YumyumDbContext(DbContextOptions<YumyumDbContext> options)
          : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.OrderId, x.MealId });


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var property = entityType.FindProperty("DeletedAt") ?? entityType.AddProperty("DeletedAt", typeof(DateTime?));

                var parameter = Expression.Parameter(entityType.ClrType);

                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(DateTime?));
                var DeletedAtProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("DeletedAt"));

                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, DeletedAtProperty, Expression.Constant(null));

                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }

        }
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["DeletedAt"] = null;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["DeletedAt"] = DateTime.Now;
                        break;
                }
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MealRating> MealRatings { get; set; }



    }
}