using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        [Remote(action:"IsEmailInUse", controller:"Account")]
        public string Email { get; set; }




        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)] // So password is hidden with **** in the view
        public string Password { get; set; }




        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)] 
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; }



        //[Display(Name = "Remember Me")]
        //public bool RememberMe { get; set; }


        //public string ErrorMessage { get; set; }

    }
}
