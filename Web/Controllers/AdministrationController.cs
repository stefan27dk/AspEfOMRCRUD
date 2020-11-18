using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.ViewModels.RolesViewModels;

namespace Web.Controllers
{

    // Class ============= || AdministrationController ||==========================================
    public class AdministrationController : Controller
    {

        
        private readonly RoleManager<IdentityRole> roleManager; // RoleManager
        private readonly UserManager<ApplicationUser> userManager; // User Manager



        //|| Constructor ||
        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }





        // Create Role - || Get ||
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }




        // Create Role - || Post ||
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = model.RoleName };  // New Role  
                IdentityResult result = await roleManager.CreateAsync(identityRole); // Insert / Create the Role

                // If OK
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
                  
                // If Error - Add errors to modelstate
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }    
            
            return View(model); // Return model with the Errors from the foreach loop
        }








         // List - Roles
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }






       // EditRole - || GET ||
        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {  
            var role = await roleManager.FindByIdAsync(Id); // Find Role    
            if(role==null) // if role dont exists
            {
                ViewBag.ErrorMessage = $"Role with ID = {Id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel { Id = role.Id, RoleName = role.Name }; // ViewModel

            foreach (var user in await userManager.Users.ToListAsync()) // Loop users
            {
                if (await userManager.IsInRoleAsync(user, role.Name)) // if user have the role add it to the UsersList in the ViewModel
                {
                    model.Users.Add(user.UserName);
                }      
            }

            return View(model);
        }


















        // EditRole - || Post ||
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id); // Find Role    
            if (role == null) // If role dont exists
            {
                ViewBag.ErrorMessage = $"Role with ID = {model.Id} cannot be found";
                return View("NotFound");
            }
            else // If Ok
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
           
        }
    }
}
