namespace TrialsSystem.UsersService.Api.Exceptions
{ 
    /// <summary>
    /// City not found
    /// </summary>
    public class TrialCityNotFoundException : Exception
    {
        public TrialCityNotFoundException(string id) {
            Id = id;            
        }

        public string Id { get; }
    }
}
