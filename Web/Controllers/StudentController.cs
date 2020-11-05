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
using Application.Services.StudentServices.StudentQueries;
using Application.Services.StudentServices.StudentCommands;
using System.Diagnostics;

namespace Web.Controllers
{
    public class StudentController : BaseController
    {

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.   


        // Index Get All- || Student View ||
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetAllStudentsQuery()));
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
        public async Task<IActionResult> Edit(int Id)  
        {     
            var student = await Mediator.Send(new GetStudentByIdQuery { Id = Id }); // Get by ID
            if (student == null) { return NotFound(); }

            return View(student);
        }



        // Edit / Update - Student || Logic || ------------------------------------------------------- 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            int UpdatedEntityId = await Mediator.Send(new UpdateStudentCommand { Id = student.Id, FirstName = student.FirstName, RowVersion = student.RowVersion});
       
            if(UpdatedEntityId == default)
            {
                return NotFound();  // Custome Error Message Later
            }   
            return RedirectToAction(nameof(Index));  
        }




                 

        // ================= Delete - || Student View || ================================================== 
        public IActionResult Delete(string firstname, int Id)
        {   
            Student student = new Student { FirstName = firstname, Id = Id }; // For showing the Name and using the Id from the IndexView to the Delete view  
            if (student.FirstName == null) {  return NotFound(); }   
            return View(student);
        }

             
        // Delete - || Logic Student || ---------------------------------------------------------------------  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {      
            int Id = await Mediator.Send(new DeleteStudentByIdCommand { Id = id });  // Delete Student
            if(Id == default)
            {
                return RedirectToAction(nameof(Index));  // Maybe Custom Eror Message 
            }   
            return RedirectToAction(nameof(Index)); // Return Index View
        }




        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}
    }
}
