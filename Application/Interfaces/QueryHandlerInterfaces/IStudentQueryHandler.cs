using Domain.Common;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.QueryHandlerInterfaces
{
    public interface IStudentQueryHandler : IQueryHandler<IBaseEntity>
    {
        Task<Student> Get_DomainModel(int id, CancellationToken cancellationToken);  // Full Model  // All Properties
        Task<StudentViewModel> Get_ViewModel(int id, CancellationToken cancellationToken); // Only VewModel    // Only Properties for the View
    }
}
