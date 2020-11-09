using Application.Interfaces;
using Application.Interfaces.QueryHandlerInterfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Query
{
  

        public class QueryHandler<TEntity, TContext> : IQueryHandler<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : IApplicationDbContext
        {

          
             //DB Context
             private readonly IApplicationDbContext context;
          
          
          
             // Constructor
             public QueryHandler(TContext context)
             {
                 this.context = context;
             }
          
          
          
          
          
          
             // Get All
             public async Task<List<TEntity>> GetAll()
             {
                 return await context.Set<TEntity>().ToListAsync(); // Return List of All Entities of this type
             }
          
          
          
          
          
             // Get
             public async Task<TEntity> Get(int id)
             {
                 return await context.Set<TEntity>().FirstOrDefaultAsync(e=> e.Id == id);
             }


        }
}
