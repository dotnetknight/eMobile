using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Domain.OrderEntity
{
    public class OrdersMap
    {
        public OrdersMap(EntityTypeBuilder<Orders> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.CreditCardNumber).IsRequired();
            entityBuilder.Property(t => t.NameOnCard).IsRequired();
            entityBuilder.Property(t => t.PhoneId).IsRequired();

            entityBuilder.HasOne(t => t.User)
                .WithMany(d => d.Order)
                .HasForeignKey(ad => ad.UserId);
        }
    }
}
