using ePizza.Services.Interfaces;
using ePizzaHub.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;


        public AuthenticationService(SignInManager<User>signManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _signManager = signManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public User AuthenticateUser(string username, string password)
        {
            var result = _signManager.PasswordSignInAsync(username ,password ,false,lockoutOnFailure:false).Result;
            if(result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(username).Result;
                var roles= _userManager.GetRolesAsync(user).Result;
                user.Roles =roles.ToArray();

                return user;
            }
            return null;
        }

        public bool CreateUser(User user, string password)
        {
            var result = _userManager.CreateAsync(user,password).Result;
            if(result.Succeeded)
            {
                string role = "Admin";
                var res = _userManager.AddToRoleAsync(user,role).Result;
                if (res.Succeeded)
                {
                    return true;
                }
               
            }
            return false;
        }

        public User GetUser(string username)
        {
            return _userManager.FindByNameAsync(username).Result;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
