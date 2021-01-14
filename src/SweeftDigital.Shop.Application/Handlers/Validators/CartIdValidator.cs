using FluentValidation;

namespace SweeftDigital.Shop.Application.Handlers.Validators
{
    public interface IHasCartIdValidator
    {
        public string Id { get; set; }
    }
    public class CartIdValidator : AbstractValidator<IHasCartIdValidator>
    {
        public CartIdValidator()
        {
            int maxLength = 250;
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.")
                .MaximumLength(maxLength).WithMessage($"Id must not exceed {maxLength}");
        }
    }
}
