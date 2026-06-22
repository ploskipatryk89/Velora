using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Velora.Domain.Abstractions;
using Velora.Infrastructure.Auth;
using Velora.Infrastructure.Context;
using Velora.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace Velora.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IJwtProvider, JWTProvider>();
            services.AddScoped<IPasswordHasher, PasswordHash>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IPaymentScheduleGenerator, PaymentScheduleGenerator>();

            services.AddDbContext<VeloraDbContext>(ctx => ctx.UseSqlServer(configuration.GetConnectionString("VeloraCS")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    message = "Musisz sie zalogowac, aby wykonac te operacje"
                });
            }, 

            OnForbidden = async context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    message = "Nie masz uprawnien do wykonania tej operacji."
                });
            }
        };
    });

            return services;


        }

      
    }
}
