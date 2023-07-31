using Application.Abstract;
using Application.Models;
using Application.Models.Authentication;
using EFProject.Data;
using EFProject.Services.UserService.Abstract;
using EFProject.Services.UserService.Concrete;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Seed;
using Infrastructure.Identity.Services;
using Infrastructure.Permission;
using Infrastructure.Services.PermissionService;
using Infrastructure.Services.UserService.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;

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


            //Token token = configuration.GetSection("token").Get<Token>();
            //byte[] secret = Encoding.ASCII.GetBytes(token.Secret);

            //services
            //    .AddAuthentication(
            //        options =>
            //        {
            //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //        })
            //    .AddJwtBearer(
            //        options =>
            //        {
            //            options.RequireHttpsMetadata = true;
            //            options.SaveToken = true;
            //            options.ClaimsIssuer = token.Issuer;
            //            options.IncludeErrorDetails = true;
            //            options.Validate(JwtBearerDefaults.AuthenticationScheme);
            //            options.TokenValidationParameters =
            //                new TokenValidationParameters
            //                {
            //                    ClockSkew = TimeSpan.Zero,
            //                    ValidateIssuer = true,
            //                    ValidateAudience = true,
            //                    ValidateLifetime = true,
            //                    ValidateIssuerSigningKey = true,
            //                    ValidIssuer = token.Issuer,
            //                    ValidAudience = token.Audience,
            //                    IssuerSigningKey = new SymmetricSecurityKey(secret),
            //                    NameClaimType = ClaimTypes.NameIdentifier,
            //                    RequireSignedTokens = true,
            //                    RequireExpirationTime = true
            //                };
            //        });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddUserManager<UserManager<ApplicationUser>>()
                    .AddSignInManager<SignInManager<ApplicationUser>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                    // Identity : Default password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                });


            //services.AddMediatR(cfg =>
            //                  cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services required using Identity
            services.AddScoped<ITokenService, TokenService>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserService1, UserService1>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            // services.AddSingleton<IAuthorizationRequirement, HasPermissionRequirement>();

            //services.AddAuthorization(options =>
            //{

            //    options.AddPolicy("HasPermission", policy =>
            //        policy.Requirements.Add(new HasPermissionRequirement()));
            //});
            // services.AddAuthorization();
            //services.AddAuthorization(
            //     options =>
            //     {
            //         options.AddPolicy(
            //             JwtBearerDefaults.AuthenticationScheme,
            //             new AuthorizationPolicyBuilder()
            //                 .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //                 .RequireAuthenticatedUser()
            //                 .Build());
            //     });

            // Register the custom authorization handler
            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();


            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy(
                        JwtBearerDefaults.AuthenticationScheme,
                        new AuthorizationPolicyBuilder()
                            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                            .RequireAuthenticatedUser()
                            .Build());
                });


            //      services.AddMediatR(cfg =>
            //cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        }

        public static async Task SeedDatabase(this IServiceProvider services, IConfiguration configuration)
        {
            using var scope = services.CreateScope();

            var servicesProvider = scope.ServiceProvider;

            var userManager = servicesProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = servicesProvider.GetRequiredService<RoleManager<IdentityRole>>();

           await ApplicationDbContextDataSeed.SeedAsync(userManager, roleManager);
        }




    }
}
