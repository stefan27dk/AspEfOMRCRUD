using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Common
{
    public class BaseEntity : IBaseEntity
    {   
        [Key]
        public int Id { get; set; }
    }
}
