using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Bills.Commands.CreateBill
{
    public class CreateBillCommandValidator : AbstractValidator<CreateBillCommand>
    {
        public CreateBillCommandValidator()
        {
            RuleFor(c => c.PaymentName)
                .NotEmpty().WithMessage("Nazwa jest wymagana")
                .MaximumLength(50).WithMessage("Nazwa nie moze przekroczyc 50 znakow");

            RuleFor(c => c.PaymentAccountNumber)
                .MaximumLength(30).WithMessage("Numer konta nie moze przekroczyc 30 znakow");

            RuleFor(c => c.Description)
                .MaximumLength(100).WithMessage("Opis nie moze przekroczyc 100 znakow");

            RuleFor(c => c.Amount)
                .NotEmpty().WithMessage("Kwota jest wymagana");

            RuleFor(c => c.DueDate)
                .NotEmpty().WithMessage("Data platnosci jest wymagana");
        }
    }
}
