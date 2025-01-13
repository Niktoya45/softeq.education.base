using Microsoft.EntityFrameworkCore;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrialsSystem.UsersService.Infrastructure.Config
{
    internal sealed class EntityDeviceConfig:IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder) {

            builder.ToTable("Devices");

            ConfigureProperty.ConfigureGeneralProperty(builder);

            builder.Property(d => d.SerialNumber)
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(d => d.Model)
                .HasColumnType("varchar")
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(d => d.FirmwareVersion)
                .HasColumnType("varchar")
                .HasMaxLength(16)
                .IsRequired();

            builder
                .HasMany(d => d.Users)
                .WithMany(d => d.Devices)
                .UsingEntity<JoinUserDevice>(
                    l => l.HasOne<User>().WithMany().HasForeignKey(j => j.UserId),
                    r => r.HasOne<Device>().WithMany().HasForeignKey(j => j.DeviceId)
                );

            builder.OwnsOne(d => d.Type,
                dt =>
                {
                    dt.ToTable("DeviceTypes");
                    dt.WithOwner().HasForeignKey("DeviceTypeId");
                    dt.HasKey(dt => dt.Id);
                    dt.Property(dt => dt.Name)
                        .HasColumnType("varchar")
                        .HasMaxLength(32)
                        .IsRequired();
                });
        }
    }
}
