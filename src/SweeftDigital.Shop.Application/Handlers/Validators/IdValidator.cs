using FluentValidation;

namespace SweeftDigital.Shop.Application.Handlers.Validators
{
    public interface IHasIdValidator
    {
        public int Id { get; set; }
    }

    public class IdValidator : AbstractValidator<IHasIdValidator>
    {
        public IdValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}
