using Domain.Authentication.DTO;
using FluentValidation;

namespace Domain.Authentication.Validation
{
    public class UserAuthenticationDtoValidation: AbstractValidator<UserAuthenticationDto>
    {
        public UserAuthenticationDtoValidation()
        {
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.UserName).NotNull();
        }
    }
}
