using Application.CQRS.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//namespace Application
//{
//    public static class DependencyInjection
//    {
//        public static IServiceCollection AddApplication(this IServiceCollection services)
//        {
//            //services.AddMediatR(typeof(DependencyInjection).Assembly);
//            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
//            services.AddMediatR(cfg =>
//     cfg.RegisterServicesFromAssembly(typeof(AddUserCommand).Assembly));
//            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//            return services;    
//        }
//    }
//}


namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}