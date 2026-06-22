using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Enums;

namespace Velora.Application.Features.RecurringBills.Commands.CreateRecurringBill
{
    public class CreateRecurringBillCommandValidator : AbstractValidator<CreateRecurringBillCommand>
    {
        public CreateRecurringBillCommandValidator()
        {
            RuleFor(c => c.PaymentName)
                .NotEmpty().WithMessage("Nazwa jest wymagana")
                .MaximumLength(50).WithMessage("Nazwa nie moze przeklroczyc 50 znakow");

            RuleFor(c => c.Description)
                .MaximumLength(100).WithMessage("Opis nie moze przekroczyc 100 znakow");

            RuleFor(c => c.PaymentAccountNumber)
                .MaximumLength(30).WithMessage("Numer konta nie moze przekroczyc 30 znakow");

            RuleFor(c => c.Amount)
                .NotEmpty().WithMessage("Kwota jest wymagana")
                .GreaterThan(0).WithMessage("Kwota musi byc powyzej 0");

            RuleFor(c => c.BankAccountId)
                .NotEmpty().WithMessage("Domyslny bank jest wymagany");

            RuleFor(x => x.Frequency)
    .IsInEnum();

            RuleFor(c => c.StartDate)
                .NotEmpty().WithMessage("Data rozpoczecia jest wymagana");

       




        }
    }
}
