using FluentValidation;
using UserService.API.Application.Query;

namespace UserService.API.Application.Validation
{
    public class ValidateGetUser : AbstractValidator<GetUserQuery>
    {
        public ValidateGetUser()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .WithMessage("Please include user Id.");
        }
    }
}
