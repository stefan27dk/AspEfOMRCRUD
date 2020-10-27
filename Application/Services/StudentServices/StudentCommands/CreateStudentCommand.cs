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

namespace Application.Services.Command
{
    // Student Command - || Class ||
    public class CreateStudentCommand : IRequest<int>
    {
        // Student - Props
        [StringLength(30, MinimumLength = 3)] // Data Field Max 30 and min 3 chars
        [Column(TypeName = "nvarchar(30)")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")] // Only Leters allowed
        public string FirstName { get; set; }



        // Handler Student - || Class ||
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            // Student Repository
            private readonly IStudentRepository _studentRepository;



            // Constructor
            public CreateStudentCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }



            // Handle Student  || Method ||
            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = new Student();
                student.FirstName = command.FirstName;
                 await _studentRepository.Add(student);
                return student.Id;  
            }
        }
    }
}
