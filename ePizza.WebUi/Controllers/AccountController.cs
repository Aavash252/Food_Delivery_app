using ePizza.Services.Interfaces;
using ePizza.WebUi.Models;
using ePizzaHub.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ePizza.WebUi.Controllers
{
    
    public class AccountController : Controller
    {

        IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber


                };
                bool result = _authService.CreateUser(user,model.Password);
            
                if(result)
                {
                    RedirectToAction("Login");
                }

            }
            return View();
        }
    }
}

