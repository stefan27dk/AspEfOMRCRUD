using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class SchoolClass : BaseEntity
    {
        // Props  
        [StringLength(5, MinimumLength = 3)] // Data Field Max 30 and min 3 chars
        [Column(TypeName = "nvarchar(10)")]
        public string ClassName { get; set; }


        //Shadow Props - Foreign Key
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
