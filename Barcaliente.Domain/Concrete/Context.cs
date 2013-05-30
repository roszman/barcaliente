using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Barcaliente.Domain.Entities;

namespace Barcaliente.Domain.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, EFConfiguration>());
        }
    }
}
