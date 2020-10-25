using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface IApplicationDbContext
    {
       //Db Sets
       DbSet<Student> Students { get; set; }  

       //Tasks
       Task<int> SaveChangesAsync();
    }
}
