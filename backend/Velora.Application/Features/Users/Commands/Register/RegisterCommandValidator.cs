using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Users.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("Pierwsze imie jest wymagane")
                .MaximumLength(50).WithMessage("Maksymalna długość imienia to 50 znaków");

            RuleFor(r => r.LastName)
                .MaximumLength(50).WithMessage("Maksymalna długość nazwiska to 50 znaków");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email jest wymagany")
                .EmailAddress().WithMessage("Niepoprawny format emaila");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Hasło jest wymagane")
                .MinimumLength(8).WithMessage("Hałso musi mieć minimum 8 znaków")
                .Must(password => password.Any(char.IsUpper)).WithMessage("Hasło musi posiadać minimum jedną wielką literę")
                .Must(password => password.Any(char.IsLower)).WithMessage("Hasło musi posiadać minimum jedną małą literę")
                .Must(password => password.Any(char.IsDigit)).WithMessage("Hasło musi posiadać minimum 1 cyfrę")
                .Must(password => password.Any(ch => !char.IsLetterOrDigit(ch))).WithMessage("Hasło musi posiadać 1 minimum znak specjalny");

            RuleFor(r => r.RepeatedPassword)
                .NotEmpty().WithMessage("Musisz powtórzyć hasło")
                .Equal(r => r.Password)
                .WithMessage("Hasła nie są takie same");
                
              
        }

       
    }
}
