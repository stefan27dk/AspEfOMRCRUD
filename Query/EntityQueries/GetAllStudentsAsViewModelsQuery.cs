using Application.Interfaces.QueryHandlerInterfaces;
using Domain.Entities;
using Domain.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Query.EntityQueries
{
    // =========== GetAll Student Query - || Class || ====================   
    public class GetAllStudentsAsViewModelsQuery : IRequest<IEnumerable<StudentViewModel>>
    {


        // =========== GetAll Student Query Handler - || Class || ====================   
        public class GetAllStudentsAsViewModelsQueryHandler : IRequestHandler<GetAllStudentsAsViewModelsQuery, IEnumerable<StudentViewModel>>
        {


            // Student - Repository
            private readonly IStudentQueryHandler _studentQueryHandler;




            // GASQH - Constructor
            public GetAllStudentsAsViewModelsQueryHandler(IStudentQueryHandler studentQueryHandler)
            {
                _studentQueryHandler = studentQueryHandler;
            }





            // GetAll- Handle Student  || Task ||   
            public async Task<IEnumerable<StudentViewModel>> Handle(GetAllStudentsAsViewModelsQuery query, CancellationToken cancellationToken)
            {
                var studentList = await _studentQueryHandler.Get_All_ViewModels_Async();
                if (studentList == null)
                {
                    return null;
                }
                return studentList.AsReadOnly();
            }
        }
    }
}
