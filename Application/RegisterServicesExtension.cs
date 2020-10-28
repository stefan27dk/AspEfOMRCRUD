using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;      
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class RegisterServicesExtension
    {

        // AddApplication
        public static void AddApplication(this IServiceCollection services)
        {
            // Mediator PAttern - Registering
            services.AddMediatR(Assembly.GetExecutingAssembly());      
        }
    }
}
