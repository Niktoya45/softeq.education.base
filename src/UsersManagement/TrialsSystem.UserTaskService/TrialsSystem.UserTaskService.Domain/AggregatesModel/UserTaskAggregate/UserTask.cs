using TrialsSystem.UserTaskService.Domain.AggregatesModel.Base;
using TrialsSystem.UserTaskService.Domain.Exceptions;

namespace TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate
{
    public class UserTask : Entity
    {
        public string Name { get; private set; }

        public string UserId { get; private set; }

        public UserTaskStatus Status { get; private set; }

        public Dictionary<string, string> AdditionalProperties { get; private set; }

        public UserTask(
            string name,
            string userId
           )
        {
            UserId = userId;

            Name = name;

            CreatedDate = DateTime.UtcNow;

            Status = UserTaskStatus.New;

            AdditionalProperties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public void SetStatus(string statusName)
        {
            UserTaskStatus status;
            try
            {
                status = (UserTaskStatus)Enum.Parse(typeof(UserTaskStatus), statusName);
            }
            catch (Exception)
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
                    _ => Status
                    }; 
        }

        public void SetUpdatedTime() 
        { 
            LastModifiedDate = DateTime.UtcNow;
        }
    }

}