using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.BankAccounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(a => a.bankName)
                .NotEmpty().WithMessage("Nazwa konta jest wymagana")
                .MaximumLength(50).WithMessage("Nazwa nie moze przekroczyc 50 znakow");

            RuleFor(a => a.bankAccountNumber)
                .NotEmpty().WithMessage("Numer konta jest wymagany")
                .MaximumLength(30).WithMessage("Numer konta nie moze przekroczyc 30 znakow");

            RuleFor(a => a.balance)
                .NotEmpty().WithMessage("Saldo poczatkowe jest wymagane");
        }
    }
}
