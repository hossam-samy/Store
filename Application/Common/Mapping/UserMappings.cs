using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries.Login;
using Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public class UserMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterCommand, AppUser>();
            config.NewConfig<AppUser, LoginResponse>();

        }
    }
}
