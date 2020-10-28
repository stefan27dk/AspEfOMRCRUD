using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {


         // Constructor - Options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {    
        }



        // On Model Creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().Property(p => p.FirstName).HasColumnType("nvarchar(30)");     
            base.OnModelCreating(modelBuilder);
        }
         

        // Db Sets
       public DbSet<Student> Students { get; set; }
       public DbSet<SchoolClass> SchoolClasses { get; set; }
  

            
        // Save Changes
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
