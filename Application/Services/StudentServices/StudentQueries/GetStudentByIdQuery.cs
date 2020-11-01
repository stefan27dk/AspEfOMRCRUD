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
            private readonly IStudentRepository _studentRepository;


            // GSBIH - || Constructor ||
            public GetStudentByIdHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }


            // GetById - Handle Student  || Task ||   
            public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken  cancellationToken)
            {
                var student = await _studentRepository.Get(query.Id, cancellationToken);
                if(student == null)
                {
                    return null;
                }
                  
                return student;
            }
        }
    }
}
