using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
	public class CreateCityCommand : IRequest<CreateCityResponse>
	{

		public CreateCityCommand(string name, string auserId)
		{
			Name = name;
		}

		public string Name { get; }
	}
}