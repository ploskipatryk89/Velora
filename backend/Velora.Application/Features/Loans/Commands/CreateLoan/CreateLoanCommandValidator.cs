using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Loans.Commands.CreateLoan
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(c => c.CreditorName)
                .NotEmpty().WithMessage("Nazwa odbiorcy jest wymagana")
                .MaximumLength(50).WithMessage("Nazwa nie moze przekroczyc 50 znakow");

            RuleFor(c => c.CreditorAccountNumber)
                .MaximumLength(50).WithMessage("Numer konta nie moze przekroczyc 50 znakow");

            RuleFor(c => c.Description)
                .MaximumLength(100).WithMessage("Opis nie moze przekroczyc 50 znakow");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Status jest wymagany");

            RuleFor(c => c.Installment)
                .NotEmpty().WithMessage("Rata kredytu jest wymagana")
                .GreaterThan(0).WithMessage("Rata musi byc wieksza od 0");

            RuleFor(c => c.PaymentStartDate)
                .LessThan(c => c.PaymentEndDate).WithMessage("Data rozpoczecia naliczania musi byc wczesniejsza od daty konca");

            RuleFor(c => c.ContractStartDate)
                .LessThan(c => c.ContractEndDate).WithMessage("Data podpisania umowy musi byc  wczesniejsza niz data zakonczenia");

            
                
        }
    }
}
