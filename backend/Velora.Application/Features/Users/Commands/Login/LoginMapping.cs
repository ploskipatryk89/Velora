using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Entities;

namespace Velora.Application.Features.Users.Commands.Login
{
    public class LoginMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginCommand, User>();
        }
    }
}
