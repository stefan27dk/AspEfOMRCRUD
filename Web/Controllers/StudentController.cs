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
using Domain.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class StudentController : BaseController
    {

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598  


        // ================= Index Get All- || Student View || ==========================================    
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
        public async Task<IActionResult> Create([Bind("FirstName,Id")] StudentViewModel student, CreateStudentCommand command)
        {    
            if (ModelState.IsValid)
            {
                command.StudentDTO.FirstName = student.FirstName;
                 
                if(await Mediator.Send(command)> 0)  // If Successful Saved to Db 
                {
                   return RedirectToAction(nameof(Index));  
                }
                else
                {
                    TempData["Save-Error"] = "Could not Save to the Database"; // Show the User Error Text
                    return View(student); // Return the Model to the View
                }

            }
            return View(student);    
        }


         




        // ================== Edit / Update - || Student View || =====================================
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)  
        {     
            var student = await Mediator.Send(new GetStudentAsViewModelByIdQuery { Id = Id }); // Get by ID
            if (student == null) { return RedirectToAction("Index", "Student"); }

            return View(student);
        }



        // Edit / Update - Student || Logic || ------------------------------------------------------- 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {
            if(ModelState.IsValid)
            {   
                int succsess = await Mediator.Send(new UpdateStudentCommand { StudentDTO = new Student { Id = model.Id, FirstName = model.FirstName, RowVersion = model.RowVersion } });
                
                if(succsess == default)
                {
                    TempData["ConcurrencyConflictMsg"] = "Concurrency Conflict - Item was Edited";
                    return RedirectToAction("Edit", "Student", $"{model.Id}");
                }   
                return RedirectToAction(nameof(Index));  
            }

            return View(model);
        }






        // ================= Delete - || Student View || ================================================== 
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var student = await Mediator.Send(new GetStudentAsViewModelByIdQuery { Id = Id }); // Get by ID
            if (student == null) 
            { 
                return NotFound(); 
            }
            
            return View(student);        
        }



             
        // Delete - || Logic Student || ---------------------------------------------------------------------  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                int sucsess = await Mediator.Send(new DeleteStudentByIdCommand { StudentDTO = new Student { Id = model.Id , RowVersion = model.RowVersion}});  // Delete Student

                if (sucsess == default) // If Error
                {     
                    TempData["ConcurrencyConflictMsg"] = "Concurrency Conflict - Item was Edited";
                    return RedirectToAction("Delete", "Student", $"{model.Id}");
                }
                
                return RedirectToAction(nameof(Index)); // Return Index View     
            }
            return View(model);
        }




        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}
    }
}
