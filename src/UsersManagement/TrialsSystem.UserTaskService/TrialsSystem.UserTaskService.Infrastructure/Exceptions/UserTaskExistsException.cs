using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTaskService.Infrastructure.Exceptions
{
    public class UserTaskExistsException : InfrastructureException
    {
        public UserTaskExistsException(string msg):base(msg) 
        {
        
        }
    }
}
