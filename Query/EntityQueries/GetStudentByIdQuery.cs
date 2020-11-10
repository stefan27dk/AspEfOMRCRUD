using Application.Interfaces.QueryHandlerInterfaces;
using Domain.Entities;
using MediatR;
using Repository.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.StudentServices.StudentQueries
{
    // =========== GetByID Student Query - || Class || ====================     
    public class GetStudentByIdQuery : IRequest<Student>
    {


        // Props
        public int Id { get; set; }



        // =========== Get - Student - By - Id - Handler - || Class || ====================  
        public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
        {



            // Student Repository
            private readonly IStudentQueryHandler _studentQueryHandler;




            // GSBIH - || Constructor ||
            public GetStudentByIdHandler(IStudentQueryHandler studentQueryHandler)
            {
                _studentQueryHandler = studentQueryHandler;
            }





            // GetById - Handle Student  || Task ||   
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken  cancellationToken)
            {
                var student = await _studentQueryHandler.GetAsync(query.Id, cancellationToken);
                if(student == null)
                {
                    return null;
                }
                  
                return student;
            }
        }
    }
}
