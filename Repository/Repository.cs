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
using System.Diagnostics.Tracing;
using System.Diagnostics;

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
        public async Task<int> Add(TEntity entity)
        {    
            context.Set<TEntity>().Add(entity);   
            return await context.SaveChangesAsync(); // Waits for async executing of "context.Set<TEntity>().Add(entity);" and than it SavesAsync. 
        }




        // Delete
        public async Task<int> Delete(TEntity entity)
        {
        
            var entity_exist = context.Set<TEntity>().FirstOrDefault(a => a.Id == entity.Id);
                   
            if (entity_exist != null)
            {
                try
                {    
                    context.Entry(entity_exist).Property("RowVersion").OriginalValue = entity.RowVersion;
                    context.Set<TEntity>().Remove(entity_exist);
                    await context.SaveChangesAsync(); // Save
                    return entity.Id;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return default;
                }

            }

            return default;


        }




        //// Get
        //public async Task<TEntity> Get(int id)
        //{
        //    return await context.Set<TEntity>().FindAsync(id); // Find
        //}





        ////Get All
        //public async Task<List<TEntity>> GetAll()
        //{
        //    return await context.Set<TEntity>().ToListAsync(); // Return List of All Entities of this type
        //}




        // Update
        public async Task<int> Update(TEntity entity)
        {
          
            // Get By Id
            var entity_exist = context.Set<TEntity>().FirstOrDefault(a => a.Id == entity.Id);


                if (entity_exist != null)
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
