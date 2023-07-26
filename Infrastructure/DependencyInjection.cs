using EFProject.Data;
using EFProject.Services.UserService.Abstract;
using EFProject.Services.UserService.Concrete;
using Infrastructure.Identity.Models;
using Infrastructure.Permission;
using Infrastructure.Services.PermissionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            }
            );

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
           // services.AddSingleton<IAuthorizationRequirement, HasPermissionRequirement>();

            //services.AddAuthorization(options =>
            //{
               
            //    options.AddPolicy("HasPermission", policy =>
            //        policy.Requirements.Add(new HasPermissionRequirement()));
            //});
            services.AddAuthorization();

            // Register the custom authorization handler
            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();
         
            //      services.AddMediatR(cfg =>
            //cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        }
    }
}
