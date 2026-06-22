using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Domain.Abstractions
{
    public interface ICurrentUser
    {
        Guid GetCurrentUser();
    }
}
