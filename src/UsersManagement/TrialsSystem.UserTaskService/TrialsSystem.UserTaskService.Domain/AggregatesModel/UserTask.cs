using System.Collections.Generic;

namespace TrialsSystem.UserTaskService.Domain.AggregatesModel
{
    public class UserTask
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Status { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime LastUpdatedDateTime { get; private set; }

        public Dictionary<string, string> AdditionalProperties { get; private set; }

        public UserTask(string id,
            string name,
            string status,
            DateTime createdDateTime,
            DateTime lastupdatedDateTime,
            Dictionary<string, string> additionalProperties)
        { 
            Id = id;
            Name = name;
            Status = status;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastupdatedDateTime;
            AdditionalProperties = additionalProperties;
            
        }


    }

}