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
                    context.Entry(entity_exist).Property("RowVersion").OriginalValue = entity.RowVersion; // Assigns the RowVersion of the Justs retrived Entity to the RowVersion of the Entity which was Retrived from the DeleteView "It uses Tracking to assign the Default value of RowVersion" if the value is assigned as usual the original value will remain the same.
                    context.Set<TEntity>().Remove(entity_exist); 
                    return await context.SaveChangesAsync(); // Save  // If RowVersion is different there will be Concurrency Exception  
                }
                catch (DbUpdateConcurrencyException)
                {
                    return default;
                }    
            }

            return default;
              
        }



      



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
                         return await context.SaveChangesAsync();  
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
