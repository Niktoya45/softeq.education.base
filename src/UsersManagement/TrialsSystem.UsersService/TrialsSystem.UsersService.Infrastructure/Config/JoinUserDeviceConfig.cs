
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrialsSystem.UsersService.Infrastructure.Config
{
    internal class JoinUserDevice() {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
    }
    internal class JoinUserDeviceConfig : IEntityTypeConfiguration<JoinUserDevice>
    {
        public void Configure(EntityTypeBuilder<JoinUserDevice> builder)
        {
            builder.HasKey(j => new {j.UserId, j.DeviceId});
        }
    }
}
