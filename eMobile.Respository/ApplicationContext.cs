using eMobile.Domain.DisplayEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.UsersEntity;
using Microsoft.EntityFrameworkCore;
using eMobile.Domain.OrderEntity;

namespace eMobile.Respository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserMap(modelBuilder.Entity<Users>());
            new PhoneMap(modelBuilder.Entity<Phone>());
            new DisplayMap(modelBuilder.Entity<Display>());
            new DimensionsMap(modelBuilder.Entity<Dimensions>());
            new MediaMap(modelBuilder.Entity<Media>());
            new OrdersMap(modelBuilder.Entity<Orders>());
        }
    }
}
