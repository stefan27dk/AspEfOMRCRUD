using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface IRepository<T> where T : class, IBaseEntity
    {
        // Tasks
        //Task<List<T>> GetAll();
        ////Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
