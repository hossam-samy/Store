using Application.Common;
using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Commands.Register
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
    {

        private readonly UserManager<AppUser> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IValidator<RegisterCommand> _validator;
        private readonly IMapper mapper;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<AppUser> userManager, IMapper mapper,
           IValidator<RegisterCommand> validator
            )
        {

            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userManager = userManager;
            this.mapper = mapper;
           _validator = validator;
        }

        public async Task<Response> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            var validationresult = await _validator.ValidateAsync(command);
            if (!validationresult.IsValid)
                return await Response.FailureAsync(validationresult.Errors.Select(i => i.ErrorMessage),"Faild" );

            if (userManager.FindByEmailAsync(command.Email) == null)
            {
                return await Response.FailureAsync("UserExist");
            }
            if (userManager.FindByNameAsync(command.UserName) == null)
            {
                return await Response.FailureAsync("UserExist");
            }
            var user = mapper.Map<AppUser>(command);
            var result = await userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {

                return await Response.FailureAsync(result.Errors, "Faild");

            }

            var roleResult = await userManager.AddToRoleAsync(user, "User");
            if (!result.Succeeded)
            {

                return await Response.FailureAsync(roleResult.Errors, "Faild");

            }

            return await Response.SuccessAsync("Success");

        }
    }
}
