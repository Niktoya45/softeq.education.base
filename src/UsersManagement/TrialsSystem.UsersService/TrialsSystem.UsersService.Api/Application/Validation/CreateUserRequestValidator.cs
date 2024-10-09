using FluentValidation;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Validation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(u => u.BirthDate).Must(d => d < DateTime.Now.AddYears(-18))
                .WithMessage("The participant should be older than 18 years.")
                ;


            RuleFor(u => u.Name).NotEqual(u => u.Surname)
                .WithMessage("Name cannot be the same as Surname")
                ;


            Include(new CreateUserRequestEmailValidator())
                ;
        }
    }

    public class CreateUserRequestEmailValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestEmailValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(u => u.Email).NotEmpty()
                    .WithMessage("Email address cannot be empty")

                .EmailAddress()
                    .WithMessage("Email address should contain '@' symbol, which cannot be placed at the beginning or the end")

                .Must(e => e.All(c => char.IsLetterOrDigit(c) || c == '@' || c == '.'))
                    .WithMessage("Only a-Z, 0-9 and '.' symbols are allowed in both parts of an email address")
                ;


            RuleFor(u => u.Email!.Split('@', StringSplitOptions.None)
                )
                .Must(parts => parts.Length == 2)
                    .WithMessage("Symbol \'@\' can be used only once")
                ;


            RuleFor(u => u.Email!.Split('@', StringSplitOptions.None)
                )
                .Must((_, parts) => parts[0].Length < 64)
                    .WithMessage("Local part is too long - no more than 63 symbols allowed")

                .Must((_, parts) => parts[1].Length < 256)
                    .WithMessage("Domain part is too long - no more than 255 symbols allowed")

                .ForEach(part => part.Must(part => !(part[0] == '.' || part[^1] == '.' || part.Contains("..")))
                        .WithMessage("Email should not begin or end with '.' symbol and should not have consecutive '.'"))

                .ForEach(part => part.Must(part => !part.Contains(' '))
                        .WithMessage("Email cannot contain spaces"))
                ;


        }
    }
}
