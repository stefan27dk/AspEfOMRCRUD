using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EntityRepositories
{
    public class StudentRepository : Repository<Student, IApplicationDbContext>
    {

        public StudentRepository(IApplicationDbContext context) : base(context)
        {   
        }

        // We can add new methods specific to the Student repository here if needed in the future
    }
}
