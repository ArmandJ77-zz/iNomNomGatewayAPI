using Domain.MenuItems.DTO;
using FluentValidation;

namespace Domain.MenuItems.Validation
{
    public class CreateMenuItemDtoValidation : AbstractValidator<CreateMenuItemDto>
    {
        public CreateMenuItemDtoValidation()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Description).NotNull();
            RuleFor(x => x.Description).Length(10,50);
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.TimeToPrep).NotNull();
        }
    }
}
