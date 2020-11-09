using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.EntityRepositories
{
    public class StudentRepository : Repository<Student, ApplicationDbContext>, IStudentRepository
    {
        //DB COntext
        private readonly IApplicationDbContext context;

          

        // Constructor
        public StudentRepository(ApplicationDbContext context) : base(context) 
        {
            this.context = context;
        }




        //// Get   
        //public async Task<Student> Get(int id, CancellationToken cancellationToken)
        //{
        //    return await context.Set<Student>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);   
        //}


        // We can add new methods specific to the Student repository here if needed in the future
    }
}
