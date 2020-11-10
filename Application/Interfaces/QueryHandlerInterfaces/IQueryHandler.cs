using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.QueryHandlerInterfaces
{
    public interface IQueryHandler<T> where T : class, IBaseEntity
    {    
        Task<List<T>> GetAllAsync();    
        Task<T> GetAsync(int id, CancellationToken cancellationToken);    
         
    }
}
