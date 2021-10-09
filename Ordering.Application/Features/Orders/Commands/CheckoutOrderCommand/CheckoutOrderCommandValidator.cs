using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrderCommand
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("{ProductId} is required.")
                .NotNull();

            RuleFor(p => p.Quantity)
               .NotEmpty().WithMessage("{Quantity} is required.");

        }
    }
}
