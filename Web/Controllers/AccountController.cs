using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.ViewModels.AccountViewModels;
using Web.ViewModels.LogIn;

namespace Web.Controllers
{

    // Acount - Controller - || Class ||
    public class AccountController : BaseController
    {
        // Managers
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        // || Constructor || ====================================================================
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }







        // Register View ========================================================================== 
        [HttpGet]
        [AllowAnonymous]   
        public IActionResult Register()
        {
            return View();
        }


        // Register - Logic =============================================================================
        [HttpPost]
        [AllowAnonymous]    
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser{ UserName = model.Email, Email = model.Email, City = model.City }; // Assign values to the new user
                var result = await userManager.CreateAsync(user, model.Password);  // Create the User

                // If All Ok
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false); // Sign In the User "Session not persistent cookie"
                    return RedirectToAction("Index", "Home");
                }

                // If Error
                foreach (var error in result.Errors) // Loop Errors
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }








        // Log In - View ==================================================================================
        [HttpGet]
        [AllowAnonymous] 
        public IActionResult LogIn()
        {
            return View();
        }



        // Log In - Logic ==================================================================================
        [HttpPost]
        [AllowAnonymous]   
        public async Task<IActionResult> LogIn(LogInViewModel model, string returnUrl)
        {
                
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false); // Sign In User

                if (result.Succeeded) // If Login Ok
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) // If redirect Url is ok and is Local Url
                    {
                       return Redirect(returnUrl); // Redirect to Return Url 
                    }    
                       return RedirectToAction("Index", "Home"); // If Redirect Url invalid return to Home Page
                }

                ModelState.AddModelError(string.Empty, "Invalid LogIn"); // If Login Not Ok
            }

            return View(model); // If modelstate is Not ok // Spelling checks password not long enought , pass string where it should be int etc.
        }










        // Log Out - Logic ==================================================================================   
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




         // Remember jquery.js, jquery.validate.js and jquery.validate.unobtrusive.js in the _Layout.cshtml
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is in use"); // Jquery Use it
            }
        }

    }
}
