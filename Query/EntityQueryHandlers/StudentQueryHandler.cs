using Application.Interfaces;
using Application.Interfaces.QueryHandlerInterfaces;
using Domain.Common;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Query.EntityQueryHandlers
{
    public class StudentQueryHandler : QueryHandler<Student, ApplicationDbContext>, IStudentQueryHandler
    {

        //DB COntext
        private readonly IApplicationDbContext context;



        // Constructor
        public StudentQueryHandler(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }




        // Get List of StudentViewModels
        public async Task<List<StudentViewModel>> Get_All_ViewModels_Async()
        {
            return await context.Set<StudentViewModel>().ToListAsync(); // Return List of All Entities of this type   
        }




        // Get StudentViewModel By Id
        public async Task<StudentViewModel> Get_ViewModelAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Set<StudentViewModel>().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
