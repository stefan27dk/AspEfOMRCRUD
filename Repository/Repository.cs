using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Common;
using System.Threading.Tasks;
using Domain.Entities;
using System.Linq;
using Persistence.Migrations;

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
        public async Task<int> Update(TEntity entity)
        {
          
            // Get By Id
            var entity_exist = context.Set<TEntity>().FirstOrDefault(a => a.Id == entity.Id);


                if (entity != null)
                {
                       try
                       {
                   
                         context.Entry(entity_exist).CurrentValues.SetValues(entity); // Replace Values
                         context.Entry(entity_exist).Property("RowVersion").OriginalValue = entity.RowVersion;
                         await context.SaveChangesAsync();
                         return entity.Id;
                
                       }
                       catch(DbUpdateConcurrencyException)
                       {
                           return default;
                       }
                    
                }

            return default;  
           
        }
    }
}
