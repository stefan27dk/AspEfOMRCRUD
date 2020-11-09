using Application.Interfaces.QueryHandlerInterfaces;
using Domain.Common;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Query.EntityQueryHandlers
{
    public class StudentQueryHandler : IStudentQueryHandler
    {

        // Get
        public Task<IBaseEntity> Get(int id)
        {
            throw new NotImplementedException();
        }


        // Get All
        public Task<List<IBaseEntity>> GetAll()
        {
            throw new NotImplementedException();
        }



        //
        public Task<Student> Get_DomainModel(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StudentViewModel> Get_ViewModel(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
