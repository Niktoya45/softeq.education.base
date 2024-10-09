using FluentValidation;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Validation
{
    public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
    {
        public CreateCityRequestValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Name).NotEmpty()
                .WithMessage("City Name cannot be empty")
                ;

            RuleFor(c => c.Name).Must(n => n.All(c => char.IsLetter(c) || c == ' '))
                .WithMessage("City Name can only contain letters and spaces")
                ;

            RuleFor(c => c.Name).Must(n => char.IsUpper(n[0])
                                           &&
                                           n.Select((c, i) => char.IsUpper(c) ? i : 0)
                                            .Where(i => i != 0)
                                            .All(i => n[i-1] == ' ')
                                           )
                .WithMessage("Each capitalized word in a city Name should be" +
                "separated by spaces")
                ;
        }
    }
}