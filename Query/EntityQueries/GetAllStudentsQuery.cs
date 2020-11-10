
using Application.Interfaces.QueryHandlerInterfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Query.EntityQueries
{
    // =========== GetAll Student Query - || Class || ====================       
    public class GetAllStudentsQuery : IRequest<IEnumerable<Student>>
    {

   

        // =========== GetAll Student Query Handler - || Class || ====================   
        public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
        {


            // Student - Repository
            private readonly IStudentQueryHandler _studentQueryHandler;
                  



            // GASQH - Constructor
            public GetAllStudentsQueryHandler(IStudentQueryHandler studentQueryHandler)
            {
                _studentQueryHandler = studentQueryHandler;
            }




            // GetAll- Handle Student  || Task ||   
            public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
            {
                var studentList = await _studentQueryHandler.GetAllAsync();
                if(studentList == null)
                {
                    return null;
                }    
                return studentList.AsReadOnly();
            }
        }
    }
}
