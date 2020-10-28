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
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {

        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
        {
            // Student - Repository
            private readonly IStudentRepository _studentRepository;




            // Constructor
            public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }


            // Handle
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
