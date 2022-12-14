using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yumyum.Data.Models;

namespace Yumyum.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YumyumDbContext(serviceProvider.GetRequiredService<DbContextOptions<YumyumDbContext>>()))
            {
                if (context == null || context.Categories == null)
                {
                    throw new ArgumentNullException("Null YumyumDbContext");
                }

                // Look for any Categories.
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Sweet",
                        CreatedAt = DateTime.Now,
                        Description = "Romantic Sweet",
                    },

                    new Category
                    {
                        Name = "Juice",
                        CreatedAt = DateTime.Now,
                        Description = "Romantic Juice",
                    }

                   
                );
                context.SaveChanges();
            }
        }
    }
}
