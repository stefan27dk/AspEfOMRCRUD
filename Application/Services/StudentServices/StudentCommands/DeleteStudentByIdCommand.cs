using Domain.Entities;
using MediatR;
using Repository.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.StudentServices.StudentCommands
{

    // =========== DeleteStudentByIdCommand || Class || ====================
    public class DeleteStudentByIdCommand :IRequest<int>
    {

        // Student - Props     
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public byte[] RowVersion { get; set; }

        public Student StudentDTO { get; set; }


        // ========== DeleteStudentByIdCommandHandler || Class || ===========
        public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, int>
        {     
            // Student Repository
            private readonly IStudentRepository _studentRepository;
             
            // || Constructor ||
            public DeleteStudentByIdCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }


            // Handle || Task ||
            public async Task<int> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
            {   
                return await _studentRepository.Delete(command.StudentDTO); 
            }
        }
    }
}
