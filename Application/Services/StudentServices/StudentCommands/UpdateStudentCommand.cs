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
        //// Student - Props     
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public byte[] RowVersion { get; set; }


        //-----New-------------------------##############
        public Student StudentDTO { get; set; }




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
                return await _studentRepository.Update(command.StudentDTO);   
            }
        }    
    }
}
