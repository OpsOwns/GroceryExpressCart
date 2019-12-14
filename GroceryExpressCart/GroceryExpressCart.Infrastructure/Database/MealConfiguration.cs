using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.SeedWork;
using GroceryExpressCart.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryExpressCart.Infrastructure.Database
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.ToTable("Meal", Schema.Grocery);
            builder.HasKey(key => key.Id);
            builder.Property(key => key.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.OwnsOne(value => value.Price).Property(_ => _.Money).HasColumnName("Price").IsRequired();
            builder.Property(value => value.MealName).HasColumnName("Meal").HasMaxLength(320).IsRequired();
            builder.Property(date => date.CreatedAt).HasColumnType(Parameters.MSSQL_DATE).IsRequired();
            builder.Property(dateModify => dateModify.ModifyAt).HasColumnType(Parameters.MSSQL_DATE).IsRequired();
        }
    }
}
