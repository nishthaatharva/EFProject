using EFProject.Data;
using EFProject.Services.UserService.Abstract;
using EFProject.Services.UserService.Concrete;
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

            services.AddScoped<IUserService, UserService>();

            //      services.AddMediatR(cfg =>
            //cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        }
    }
}
