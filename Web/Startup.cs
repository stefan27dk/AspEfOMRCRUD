using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Repository.EntityRepositories;
using Web.Data;

namespace Web
{
    public class Startup
    {
        // Startup
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // Configure Services
        public void ConfigureServices(IServiceCollection services)// This method gets called by the runtime. Use this method to add services to the container.
        {

             services.AddDbContext<LogInContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
                  //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                  //.AddEntityFrameworkStores<LogInContext>();

            // Log In
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });


            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddScoped<IStudentRepository, StudentRepository>(); // Student Repository   
            services.AddControllersWithViews();


            


        }

       



        // Configure
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {





            // Default Code------------------------------------------------------------------------------------------------------------------->
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();   
            app.UseRouting();



            // Log In 
            app.UseAuthentication();
            app.UseAuthorization();



            // End Points
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();  // Log In   
            });
        }
    }
}
