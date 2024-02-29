using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Queries.Login
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public bool IsAuthenticated { get; set; }   
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Gendre { get; set; }
        public DateTime StartingAt { get; set; }
        public string Token { get; set; }
    }
}
