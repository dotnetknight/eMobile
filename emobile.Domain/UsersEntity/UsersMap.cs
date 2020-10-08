using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Domain.UsersEntity
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<Users> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();

            entityBuilder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(254);

            entityBuilder.HasMany(t => t.Address)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);
        }
    }
}
