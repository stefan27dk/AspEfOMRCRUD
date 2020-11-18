using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }


         // ||Constructor||
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
    }
}
