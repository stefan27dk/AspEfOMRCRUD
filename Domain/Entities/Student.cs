using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        // Props
        [StringLength(30, MinimumLength = 3)] // Data Field Max 30 and min 3 chars
        [Column(TypeName = "nvarchar(30)")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")] // Only Leters allowed
        public string FirstName { get; set; }

    }
}
