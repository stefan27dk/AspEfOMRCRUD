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
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        //Tasks
        Task<int> SaveChangesAsync();
    }
}
