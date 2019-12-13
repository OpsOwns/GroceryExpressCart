using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.Settings;
using GroceryExpressCart.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryExpressCart.Infrastructure.Database
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", Schema.Grocery);
            builder.HasKey(key => key.Id);
            builder.Property(key => key.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(value => value.DateOrder).HasColumnName("OrderDate").IsRequired();
            builder.Property(date => date.CreatedAt).HasColumnType(Parameters.MSSQL_DATE).IsRequired();
            builder.Property(dateModify => dateModify.ModifyAt).HasColumnType(Parameters.MSSQL_DATE).IsRequired();
            builder.HasOne(value => value.Person).WithMany(many => many.Orders).HasForeignKey(fKey => fKey.MemberShipId);
            builder.HasOne(value => value.Meal).WithMany(many => many.Orders).HasForeignKey(fKey => fKey.MealId);
        }
    }
}
