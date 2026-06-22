using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.BankAccounts.Commands.AddAccount
{
    public class AddBankCommandValidator : AbstractValidator<AddBankAccountCommand>
    {
        public AddBankCommandValidator()
        {
            RuleFor(a => a.BankName)
                .NotEmpty().WithMessage("Nazwa konta jest wymagana")
                .MaximumLength(50).WithMessage("Nazwa nie moze przekroczyc 50 znakow");

            RuleFor(a => a.BankAccountNumber)
                .NotEmpty().WithMessage("Numer konta jest wymagany")
                .MaximumLength(30).WithMessage("Numer konta nie moze przekroczyc 30 znakow");

            RuleFor(a => a.Balance)
                .NotEmpty().WithMessage("Saldo poczatkowe jest wymagane");
        }

        
    }
}
