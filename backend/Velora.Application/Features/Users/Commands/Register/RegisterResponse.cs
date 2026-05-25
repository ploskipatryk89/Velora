using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Application.Features.Users.Commands.Register
{
    public record RegisterResponse(
        Guid UserId,
        string Email
        );
}
