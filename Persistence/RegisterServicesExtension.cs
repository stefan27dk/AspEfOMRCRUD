using Application.Interfaces;
using Application.Services.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class RegisterServicesExtension
    {

        // AddPersistence ::Method::
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //============= Db Context - Registration ====================
            services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); // Connectionstring
            //b => b.MigrationsAssembly("AspEfOMRCRUD.Persistence.Migrations"))); // Migrations Path
            // AddDbContextPool - Is Used for better performance. Get allways an instance of already created DbContext so its not created every time                  
            
            //============= Db Context - Interface - Registration =========   
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()); // Register the IApplication Db context



            // Db Context is registered here like in the startup.cs, this is extension class of the startup class
            // This Class is registered in the startup.cs
        }
    }
}
