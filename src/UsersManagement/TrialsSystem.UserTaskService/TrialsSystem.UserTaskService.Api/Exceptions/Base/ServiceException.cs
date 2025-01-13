
namespace TrialsSystem.UserTaskService.Api.Exceptions.Base
{

    /// <summary>
    /// Abstract exception class
    /// </summary>
    public abstract class ServiceException : Exception
    {
        public ServiceException(string msg):base(msg)
        {

        }
    }
}