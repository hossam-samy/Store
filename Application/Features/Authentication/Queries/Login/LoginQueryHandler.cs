using Application.Common;
using Application.Interfaces;
using Domain.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication.Queries.Login
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IMapper mapper;

        public LoginQueryHandler(UserManager<AppUser> userManager, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.mapper = mapper;
        }

        public async Task<Response> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(query.UserName);
            if (user == null||!await userManager.CheckPasswordAsync(user,query.Password))
            { 
                return await Response.FailureAsync("Faild");
            }
            var response = mapper.Map<LoginResponse>(user);
            response.Token = await jwtTokenGenerator.GenerateToken(user);
            response.IsAuthenticated = true;    
            return await Response.SuccessAsync(response,"Success");
        }
    }
}
