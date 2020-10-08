using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMobile.Domain.MediaEntity
{
    public class MediaMap
    {
        public MediaMap(EntityTypeBuilder<Media> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Photo).IsRequired();
            entityBuilder.Property(p => p.Video).IsRequired();
        }
    }
}
