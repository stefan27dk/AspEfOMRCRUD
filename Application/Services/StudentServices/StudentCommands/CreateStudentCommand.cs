using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Services.Command
{
    public class CreateStudentCommand : IRequest<int>
    {
        // Props
        [StringLength(30, MinimumLength = 3)] // Data Field Max 30 and min 3 chars
        [Column(TypeName = "nvarchar(30)")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] // Only Leters allowed
        public string FirstName { get; set; }
    }
}
