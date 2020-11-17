using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels.RolesViewModels;

namespace Web.Controllers
{

    // Class ============= || AdministrationController ||==========================================
    public class AdministrationController : Controller
    {

        // RoleManager
        private readonly RoleManager<IdentityRole> roleManager;



        //|| Constructor ||
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
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


    }
}
