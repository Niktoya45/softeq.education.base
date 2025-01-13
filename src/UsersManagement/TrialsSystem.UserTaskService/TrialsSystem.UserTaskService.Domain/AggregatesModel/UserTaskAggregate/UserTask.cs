using TrialsSystem.UserTaskService.Domain.AggregatesModel.Base;
using TrialsSystem.UserTaskService.Domain.Exceptions;

namespace TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate
{
    public class UserTask : Entity
    {
        public string Name { get; set; }

        public string UserId { get; set; }

        public UserTaskStatus Status { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }


        public UserTask() { }
        public UserTask(
            string name,
            string userId,
            Dictionary<string, string>? additionalProperties = null
           )
        {
            UserId = userId;

            Name = name;

            CreatedDate = DateTime.UtcNow;

            Status = UserTaskStatus.New;

            AdditionalProperties = additionalProperties ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            IsDeleted = false;
        }

        public void SetStatus(string statusName)
        {
            UserTaskStatus status;
            try
            {
                status = (UserTaskStatus)Enum.Parse(typeof(UserTaskStatus), statusName);
            }
            catch (ArgumentException)
            {
                throw new InvalidUserTaskStatusException(statusName);
            }

            Status = status == Status ? Status :
                (Status) switch
                {
                    UserTaskStatus.New =>
                        status,
                    UserTaskStatus.InProgress =>
                        status == UserTaskStatus.New ? throw new InvalidTaskStatusChangeException(Status.ToString(), statusName) : status,
                    UserTaskStatus.Closed =>
                        status == UserTaskStatus.Reopen ? throw new InvalidTaskStatusChangeException(Status.ToString(), statusName) : status,
                    UserTaskStatus.Reopen =>
                        status == UserTaskStatus.New ? throw new InvalidTaskStatusChangeException(Status.ToString(), statusName) : status,
                    _ => UserTaskStatus.New
                };
        }

        public void SetUpdatedTime()
        {
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetDeleted()
        {
            IsDeleted = true;
        }
    }

}