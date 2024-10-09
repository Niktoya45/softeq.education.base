namespace TrialsSystem.UsersService.Api.Exceptions.Base
{
    public abstract class ServiceException : Exception
    {
        public ServiceException()
        { 
        }
        public ServiceException(string msg):base(msg)
        {
        }
    }
}
