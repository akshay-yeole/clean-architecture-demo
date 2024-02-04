using application.Dtos;
using application.Enums;
using application.Exceptions;
using application.Interfaces;
using application.Wrappers;
using Microsoft.AspNetCore.Identity;
using Persistance.IdentityModels;

namespace Persistance.SharedServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<Guid>> RegisterUser(RegisterRequest registerRequest){
            var user = await _userManager.FindByEmailAsync(registerRequest.Email);
            if (user != null)
            {
                throw new ApiExceptions($"User Already Exists {registerRequest.Email}");
            }

            var userModel = new ApplicationUser();
            userModel.UserName = registerRequest.UserName;
            userModel.FirstName = registerRequest.FirstName;
            userModel.LastName = registerRequest.LastName;
            userModel.Email = registerRequest.Email;
            userModel.EmailConfirmed = true;
            userModel.PhoneNumberConfirmed = true;

           var result = await _userManager.CreateAsync(userModel, registerRequest.ConfirmedPassword);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userModel, Roles.SuperAdmin.ToString());
                await _userManager.AddToRoleAsync(userModel, Roles.admin.ToString());
                await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
                return new ApiResponse<Guid>(userModel.Id,"User Registered Successfully");
            }
            else
            {
                throw new ApiExceptions(result.Errors.ToString());
            }
        }
    }
}
