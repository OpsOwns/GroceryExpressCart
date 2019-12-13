using GroceryExpressCart.Common.Settings;
using GroceryExpressCart.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GroceryExpressCart.Infrastructure.Database
{
    public class GroceryContext : DbContext
    {
        private readonly DatabaseSettings _databaseSettings;
        public GroceryContext(DbContextOptions<GroceryContext> options, DatabaseSettings databaseSettings) : base(options)
        {
            _databaseSettings = databaseSettings;
        }
        #region DbSets
        public DbSet<MemberShip> MemberShip { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Order> Order { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_databaseSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("GroceryDB");
                return;
            }
            optionsBuilder.UseSqlServer(_databaseSettings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new MemberShipConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
