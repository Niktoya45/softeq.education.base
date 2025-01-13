using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;

namespace TrialsSystem.UsersService.Infrastructure.Config
{
    internal sealed class EntityUserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            ConfigureProperty.ConfigureGeneralProperty(builder);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Name)
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(u => u.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();

            builder.HasOne(u => u.City).WithMany().HasForeignKey("CityId");
            builder.OwnsOne(u => u.Gender, ug =>
                            {
                                ug.ToTable("Genders");
                                ug.WithOwner().HasForeignKey("GenderId");
                                ug.HasKey(g => g.Id);
                                ug.Property(g => g.Name)
                                    .HasColumnType("varchar")
                                    .HasMaxLength(8)
                                    .IsRequired();
                            });

            builder
                .HasMany(u => u.Devices)
                .WithMany(d => d.Users)
                .UsingEntity<JoinUserDevice>(
            l => l.HasOne<Device>().WithMany().HasForeignKey(j => j.DeviceId),
            r => r.HasOne<User>().WithMany().HasForeignKey(j => j.UserId)
                );

            builder.Property(u => u.BirthDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(u => u.Height)
                .HasColumnType("float")
                .IsRequired(false);

            builder.Property(u => u.Weight)
                .HasColumnType("float")
                .IsRequired(false);

        }
    }
}
