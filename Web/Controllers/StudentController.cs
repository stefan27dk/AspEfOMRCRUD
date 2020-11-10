using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Context;
using Application.Interfaces;
using Application.Services.Command;     
using Application.Services.StudentServices.StudentCommands;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.VisualBasic;
using Query.EntityQueryHandlers;
using Query.EntityQueries;

namespace Web.Controllers
{
     
    public class StudentController : BaseController
    {

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598  


        // Index Get All- || Student View ||
   
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {   
            return View(await Mediator.Send(new GetAllStudentsAsViewModelsQuery()));
        }





        //// GET: Student/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}




        // ================= Create - || Student View || ========================================== 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        // Create - || Logic - Student || ----------------------------------------------------------- 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,Id")] Student student, CreateStudentCommand command)
        {
            if (ModelState.IsValid)
            {    
                 command.FirstName = student.FirstName;
                 await Mediator.Send(command);   
                 return RedirectToAction(nameof(Index));
            }
            return View(student);
        }


         




        // ================== Edit / Update - || Student View || =====================================
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)  
        {     
            var student = await Mediator.Send(new GetStudentByIdQuery { Id = Id }); // Get by ID
            if (student == null) { return RedirectToAction("Index", "Student"); }

            return View(student);
        }



        // Edit / Update - Student || Logic || ------------------------------------------------------- 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student model)
        {
            if(ModelState.IsValid)
            {   
                int UpdatedEntityId = await Mediator.Send(new UpdateStudentCommand { Id = model.Id, FirstName = model.FirstName, RowVersion = model.RowVersion});
                
                if(UpdatedEntityId == default)
                {
                    TempData["ConcurrencyConflictMsg"] = "Concurrency Conflict - Item was Edited";
                    return RedirectToAction("Edit", "Student", $"{model.Id}");
                }   
                return RedirectToAction(nameof(Index));  
            }

            return View();
        }




                 

        // ================= Delete - || Student View || ================================================== 
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var student = await Mediator.Send(new GetStudentByIdQuery { Id = Id }); // Get by ID
            if (student == null) 
            { 
                return NotFound(); 
            }
            
            return View(student);        
        }



             
        // Delete - || Logic Student || ---------------------------------------------------------------------  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Student model)
        {
            if (ModelState.IsValid)
            {
                int Id = await Mediator.Send(new DeleteStudentByIdCommand { Id = model.Id, FirstName = model.FirstName, RowVersion = model.RowVersion });  // Delete Student
                if (Id == default)
                {     
                    TempData["ConcurrencyConflictMsg"] = "Concurrency Conflict - Item was Edited";
                    return RedirectToAction("Delete", "Student", $"{model.Id}");
                }
                return RedirectToAction(nameof(Index)); // Return Index View
            }
            return View();
        }




        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}
    }
}
