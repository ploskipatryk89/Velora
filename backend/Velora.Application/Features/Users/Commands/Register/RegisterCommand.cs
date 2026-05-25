using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Velora.Application.Features.Users.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string RepeatedPassword
        ) : IRequest<RegisterResponse>;
}
