using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Queries.Login
{
    public class LoginQuery : IRequest<Response>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
