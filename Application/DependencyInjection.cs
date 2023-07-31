using Application.Models.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddMediatR(cfg =>
            //        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            //services.AddAuthentication(options => {
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //options.TokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = true,
            //    ValidateAudience = true,
            //    ValidateLifetime = true,
            //    ValidateIssuerSigningKey = true,
            //    ValidIssuer = Configuration["Jwt:Issuer"],
            //    ValidAudience = Configuration["Jwt:Audience"],
            //    //RoleClaimType ="Test",
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //};
            //});


            Token token = Configuration.GetSection("token").Get<Token>();
            byte[] secret = Encoding.ASCII.GetBytes(token.Secret);

            services
                .AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(
                    options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = true;
                        options.ClaimsIssuer = token.Issuer;
                        options.IncludeErrorDetails = true;
                        options.Validate(JwtBearerDefaults.AuthenticationScheme);
                        options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                ClockSkew = TimeSpan.Zero,
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = token.Issuer,
                                ValidAudience = token.Audience,
                                IssuerSigningKey = new SymmetricSecurityKey(secret),
                                NameClaimType = ClaimTypes.NameIdentifier,
                                RequireSignedTokens = true,
                                RequireExpirationTime = true
                            };
                    });



            //services.AddAuthorization(
            //    options =>
            //    {
            //        options.AddPolicy(
            //            JwtBearerDefaults.AuthenticationScheme,
            //            new AuthorizationPolicyBuilder()
            //                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //                .RequireAuthenticatedUser()
            //                .Build());
            //    });


            services.AddMediatR(cfg =>
                   cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
        
    }
}