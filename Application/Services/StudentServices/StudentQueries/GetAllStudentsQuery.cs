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
    // =========== GetAll Student Query - || Class || ====================       
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {



        // =========== GetAll Student Query Handler - || Class || ====================   
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
        {
            // Student - Repository
            private readonly IStudentRepository _studentRepository;
                  

            // GASQH - Constructor
            public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }


            // GetAll- Handle Student  || Task ||   
            public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
            {
                var studentList = await _studentRepository.GetAll();
                if(studentList == null)
                {
                    return null;
                }

                return studentList.AsReadOnly();
            }
        }
    }
}
