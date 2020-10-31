using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Repository.EntityRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.StudentServices.StudentCommands
{
    // =========== Update Student Command - || Class || ====================    
    public class UpdateStudentCommand : IRequest<int>
    {    
        // Student - Props
        [StringLength(30, MinimumLength = 3)] // Data Field Max 30 and min 3 chars
        [Column(TypeName = "nvarchar(30)")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")] // Only Leters allowed
        public int Id { get; set; }
        public string FirstName { get; set; }



        // =========== Update Student Command Handler - || Class || ====================     
        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {      
            // Student Repository
            private readonly IStudentRepository _studentRepository;


            // USC - || Constructor ||
            public UpdateStudentCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }


            // Update - Handle Student  || Task ||    
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {

                Student student = new Student();
                student.FirstName = command.FirstName;
                student.Id = command.Id;
                   
                 return await _studentRepository.Update(student);

            }
        }    
    }
}
