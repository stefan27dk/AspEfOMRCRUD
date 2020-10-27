using Application.Interfaces;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.EntityRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        // Get by ID
        Task<Student> Get(int id, CancellationToken cancellationToken);          
    }
}