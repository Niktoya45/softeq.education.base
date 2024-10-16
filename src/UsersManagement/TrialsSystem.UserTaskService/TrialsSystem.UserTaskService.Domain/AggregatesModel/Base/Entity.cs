using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTaskService.Domain.AggregatesModel.Base
{
    public class Entity
    {
        public string Id { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public DateTime CreatedDate { get; protected set; }
        public DateTime LastModifiedDate { get; protected set; }

    }
}