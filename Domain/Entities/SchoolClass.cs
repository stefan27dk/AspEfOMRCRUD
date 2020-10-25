using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SchoolClass : BaseEntity
    {
        // Props    
        public string ClassName { get; set; }


        //Shadow Props - Foreign Key
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
