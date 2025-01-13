using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UserTaskService.Infrastructure.Exceptions
{
    public class InnerDbException:InfrastructureException
    {
        public InnerDbException(string msg):base(msg)
        {
        }
    }
}
