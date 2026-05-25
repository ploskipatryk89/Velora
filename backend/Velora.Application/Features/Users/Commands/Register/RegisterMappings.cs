using Mapster;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Application.Features.Users.Commands.Register;
using Velora.Domain.Entities;

namespace Velora.Application.Features.Users.Commands.Register
{
    public class RegisterMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterCommand, User>();
        }
    }
}
