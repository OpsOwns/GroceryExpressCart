using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.SeedWork;
using GroceryExpressCart.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryExpressCart.Infrastructure.Database
{
    public class MemberShipConfiguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.ToTable("MemberShip", Schema.Grocery);
            builder.HasKey(key => key.Id);
            builder.Property(key => key.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.OwnsOne(value => value.Login).Property(_ => _.LoginValue).HasColumnName("Login").HasMaxLength(32).IsRequired();
            builder.OwnsOne(value => value.Email).Property(_ => _.EmailValue).HasColumnName("Email").IsRequired();
            builder.OwnsOne(value => value.Password).Property(_ => _.PasswordValue).HasColumnName("Password").IsRequired();
            builder.Property(date => date.CreatedAt).HasColumnType(Parameters.MSSQL_DATE).IsRequired();
            builder.Property(dateModify => dateModify.ModifyAt).HasColumnType(Parameters.MSSQL_DATE).IsRequired();
        }
    }
}
