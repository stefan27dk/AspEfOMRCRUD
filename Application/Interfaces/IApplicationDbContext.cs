using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.CodeAnalysis;

namespace Application.Interfaces
{
    public  interface IApplicationDbContext 
    {
        //Db Sets
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        // Entry
        public EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class; 
        // Used in the Repository for Update Operation
       

        //Tasks
        Task<int> SaveChangesAsync();
    }
}
