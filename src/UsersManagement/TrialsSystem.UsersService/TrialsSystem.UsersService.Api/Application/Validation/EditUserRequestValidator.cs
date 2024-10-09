using FluentValidation;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Validation
{
    public class EditUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public EditUserRequestValidator()
        {
            RuleFor(u => u.BirthDate)
                .Must(u => u < DateTime.Now.AddYears(-18))
                .WithMessage("The participant should be older than 18 years.")
                ;

            RuleFor(u => u.Name).NotEqual(u => u.Surname)
                .WithMessage("Name cannot be the same as Surname")
                ;
        }
    }
}
