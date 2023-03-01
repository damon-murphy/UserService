using FluentValidation;
using UserService.Application.Command;

namespace UserService.Application.Validation
{
    public class ValidateCreateUser : AbstractValidator<CreateUserCommand>
    {
        public ValidateCreateUser()
        {
            RuleFor(user => user.Id)
                .Null()
                .WithMessage("Id must be null.");

            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("First name can not be null or white space.")
                .Matches("^[a-zA-Z]*$")
                .WithMessage("First name cannot contain numbers or special characters.");

            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("Last name can not be null or white space.")
                .Matches("^[a-zA-Z]*$")
                .WithMessage("Last name can not contain numbers or special characters.");

            RuleFor(user => user.Address)
                .NotEmpty()
                .WithMessage("Address can not be null or white space.");

            RuleFor(user => user.DateOfBirth)
                .NotNull()
                .WithMessage("Date of birth can not be null.")
                .LessThan(DateTimeOffset.Now)
                .WithMessage("Date of birth must be in the past.");

        }
    }
}
