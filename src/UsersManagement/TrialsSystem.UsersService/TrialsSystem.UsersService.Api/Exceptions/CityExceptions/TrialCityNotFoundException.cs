using TrialsSystem.UsersService.Api.Exceptions.Base;

namespace TrialsSystem.UsersService.Api.Exceptions
{ 
    /// <summary>
    /// City not found
    /// </summary>
    public class TrialCityNotFoundException : ServiceException
    {
        public TrialCityNotFoundException(string id):base($"City with Id {id} is not found") {
            Id = id;            
        }

        public string Id { get; }
    }
}
