
namespace TrialsSystem.UserTaskService.Api.Exceptions.Base
{

    /// <summary>
    /// Abstract exception class
    /// </summary>
    public abstract class ServiceException : Exception
    {
        public string Id { get; protected set; }

        public ServiceException(string msg):base(msg)
        {

        }
    }
}