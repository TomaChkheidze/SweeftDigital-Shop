using FluentValidation;
using SweeftDigital.Shop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Handlers.Carts.Commands
{
    public class CartOperationValidator : AbstractValidator<CartItemOperation>
    {
        public CartOperationValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Cart Id is required");

            RuleFor(v => v.Secret)
                .NotEmpty().WithMessage("Cart Secret is required");

            RuleFor(v => v.ItemId)
                .NotEmpty().WithMessage("Item Id is required");
        }
    }
}
