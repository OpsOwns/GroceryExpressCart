using GroceryExpressCart.Common.Extension;
using GroceryExpressCart.Common.SeedWork;
using GroceryExpressCart.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryExpressCart.Infrastructure.Database
{
    public class SystemNotificationConfiguration : IEntityTypeConfiguration<SystemNotification>
    {
        public void Configure(EntityTypeBuilder<SystemNotification> builder)
        {
            builder.ToTable("SystemNotification", Schema.Grocery);
            builder.HasKey(key => key.Id);
            builder.Property(key => key.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(message => message.Message).HasColumnName("Statement").IsRequired();
            builder.Property(date => date.InvokedAt).HasColumnName("DateInvoke")
                .HasColumnType(Parameters.MSSQL_DATE).IsRequired();
        }
    }
}
