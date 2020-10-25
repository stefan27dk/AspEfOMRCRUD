using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Common;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
     where TEntity : class, IBaseEntity where TContext : IApplicationDbContext     
    {
        //DB Context
        private readonly TContext context;



        // Constructor
        public Repository(TContext context)
        {
            this.context = context;
        }




        // ADD
        public async Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }




        // Delete
        public Task<TEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }




        // Get
        public Task<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }




        //Get All
        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }




        // Update
        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
