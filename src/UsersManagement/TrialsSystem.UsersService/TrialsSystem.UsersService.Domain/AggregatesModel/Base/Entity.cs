
namespace TrialsSystem.UsersService.Domain.AggregatesModel.Base
{
    public class Entity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
