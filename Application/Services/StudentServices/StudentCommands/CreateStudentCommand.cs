using Application.Interfaces;
using Domain.Entities;
using Domain.ViewModels;
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
    // =========== Student Command || Class || ====================     
    public class CreateStudentCommand : IRequest<int>
    {
        // Student - Props    
        //public string FirstName { get; set; }


        //-----New-------------------------##############
        public Student StudentDTO { get; set; } = new Student();



        // =========== Handler Student  || Class || ==================     
        public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
        {
            // Student Repository
             private readonly IStudentRepository _studentRepository;
                                                                   

            // || Constructor ||
            public CreateStudentCommandHandler(IStudentRepository studentRepository)
            {
                _studentRepository = studentRepository;
            }



            // Handle Student  || Task ||
            public async Task<int> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
            {   
                await _studentRepository.Add(command.StudentDTO);
                return command.StudentDTO.Id;
            }
        }
    }
}
