using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Users.Commands.Login
{
    public record LoginCommand(
        string Email,
        string Password
        ) : IRequest<LoginResponse>;
}
