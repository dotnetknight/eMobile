using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Domain.AddressEntity
{
    public class AddressMap
    {
        public AddressMap(EntityTypeBuilder<Address> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.Property(p => p.Phone).IsRequired();

            entityBuilder.Property(p => p.Address1)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(p => p.Address2)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
