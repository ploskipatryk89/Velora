using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Domain.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(User User);
    }
}
