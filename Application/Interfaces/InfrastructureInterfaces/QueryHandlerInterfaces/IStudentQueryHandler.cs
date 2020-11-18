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
    public interface IStudentQueryHandler : IQueryHandler<Student>
    {
        Task<List<StudentViewModel>> Get_All_ViewModels_Async(); // Only VewModel    // Only Properties for the View
        Task<StudentViewModel> Get_ViewModelAsync(int id, CancellationToken cancellationToken); // Only VewModel    // Only Properties for the View
    }
}
