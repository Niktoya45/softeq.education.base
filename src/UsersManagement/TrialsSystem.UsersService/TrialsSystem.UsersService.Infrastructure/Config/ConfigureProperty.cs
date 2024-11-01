using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Infrastructure.Config
{
    static public class ConfigureProperty
    {
        static public void ConfigureGeneralProperty<T>(EntityTypeBuilder<T> builder) where T:Entity
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.IsDeleted)
                .HasColumnType("bit");

            builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
