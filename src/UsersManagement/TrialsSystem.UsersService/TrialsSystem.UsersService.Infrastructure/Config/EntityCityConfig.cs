using Microsoft.EntityFrameworkCore;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrialsSystem.UsersService.Infrastructure.Config
{
    internal sealed class EntityCityConfig:IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder) {

            builder.ToTable("Cities");

            ConfigureProperty.ConfigureGeneralProperty(builder);

            builder.Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(32);
        }
    }
}
