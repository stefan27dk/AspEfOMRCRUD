using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Query
{
    public static class RegisterServicesExtension
    {

        // AddQuery
        public static void AddQuery(this IServiceCollection services)
        {
            // Mediator PAttern - Registering
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
