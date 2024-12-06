
namespace TrialsSystem.UsersService.Infrastructure.Exceptions
{
    public class InfrastructureException
    {
        IEnumerable<string> AdditionalInformation;
        public InfrastructureException(IEnumerable<string> additionalInformation)
        {
            AdditionalInformation = additionalInformation;
        }
    }
}
