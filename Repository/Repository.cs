using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Common;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
     where TEntity : class, IBaseEntity 
     where TContext : IApplicationDbContext     
    {
        //DB Context
        private readonly IApplicationDbContext context;



        // Constructor
        public Repository(TContext context)
        {
            this.context = context;
        }




        // ADD
        public async Task<TEntity> Add(TEntity entity)
        {    
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync(); // Waits for async executing of "context.Set<TEntity>().Add(entity);" and than it SavesAsync. 
            return entity;
        }




        // Delete
        public async Task<TEntity> Delete(int id)
        {
            // Find Entity
            var entity = await context.Set<TEntity>().FindAsync(id);
            if(entity == null)
            {
                return entity;
            }

            // Remove
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync(); // Save

            return entity;
        }




        //// Get
        //public async Task<TEntity> Get(int id)
        //{
        //    return await context.Set<TEntity>().FindAsync(id); // Find
        //}





        //Get All
        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync(); // Return List of All Entities of this type
        }




        // Update
        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
