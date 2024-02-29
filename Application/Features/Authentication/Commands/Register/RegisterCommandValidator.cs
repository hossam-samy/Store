using Application.Features.Authentication.Commands.Register;
using Application.Interfaces;
using Domain.Models;
using FluentValidation;

namespace application.features.authentication.commands.register
{
    public class Registercommandvalidator : AbstractValidator<RegisterCommand>
    {
        public Registercommandvalidator(IUnitOfWork  _unitOfWork)
        {
            RuleFor(i => i.Email).MustAsync(async (email,_) =>
            {

                if (email == null || !email.EndsWith("@gmail.com")) return false;
                
                else if(_unitOfWork.Repository<AppUser>().Get(i=>i.Email==email).Result.FirstOrDefault()!=null) return false;
                
                return true;

            }).WithMessage("Email is not valid");

            RuleFor(i => i.PhoneNumber).MustAsync(async (phone, _) =>
            {

                if (phone == null || 
                phone.Length!=11||
                !phone.StartsWith("010")||
                !phone.StartsWith("011")|| 
                !phone.StartsWith("012")|| 
                !phone.StartsWith("015")) 
                    return false;

                else if (_unitOfWork.Repository<AppUser>().Get(i => i.PhoneNumber == phone).Result.FirstOrDefault() != null) return false;

                return true;

            }).WithMessage("PhoneNumber is not valid");
            RuleFor(i => i.UserName).MustAsync(async (username, _) =>
            {

                if (username == null)
                    return false;

                else if (_unitOfWork.Repository<AppUser>().Get(i => i.UserName == username).Result.FirstOrDefault() != null) return false;

                return true;

            }).WithMessage("UserName is not valid");

            RuleFor(i => i.StartingAt).MustAsync(async (startingat, _) =>
            {

                if (startingat == null)
                    return false;

                else if (startingat>DateTime.Now) return false;

                return true;

            }).WithMessage("StartingAt is not valid");
            
        }
    }
}
