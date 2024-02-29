using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<Response>
    {
        public string UserName { get; set; }


        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Gendre { get; set; }
        public DateTime StartingAt { get; set; }
        public string Password { get; set; }
    }
}
