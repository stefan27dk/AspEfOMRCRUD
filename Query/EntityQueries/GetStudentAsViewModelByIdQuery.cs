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

    // =========== GetByID Student Query - || Class || ====================     

    public class GetStudentAsViewModelByIdQuery : IRequest<StudentViewModel>
    {


        // Props
        public int Id { get; set; }



        // =========== Get - Student - By - Id - Handler - || Class || ====================  
        public class GetStudentByIdHandler : IRequestHandler<GetStudentAsViewModelByIdQuery, StudentViewModel>
        {



            // Student Repository
            private readonly IStudentQueryHandler _studentQueryHandler;




            // GSBIH - || Constructor ||
            public GetStudentByIdHandler(IStudentQueryHandler studentQueryHandler)
            {
                _studentQueryHandler = studentQueryHandler;
            }





            // GetById - Handle Student  || Task ||   
            public async Task<StudentViewModel> Handle(GetStudentAsViewModelByIdQuery query, CancellationToken cancellationToken)
            {
                var student = await _studentQueryHandler.Get_ViewModelAsync(query.Id, cancellationToken);
                if (student == null)
                {
                    return null;
                }

                return student;
            }

           
        }
    }
}
