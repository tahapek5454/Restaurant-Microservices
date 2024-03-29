﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurant.Services.CouponAPI.Data.Contexts;
using System.Reflection;

namespace Restaurant.Services.CouponAPI
{
    public static class ServiceRegistration
    {
        public static void AddCouponServices(this IServiceCollection serviceCollection, string connecitonString)
        {
            serviceCollection.AddDbContext<AppDbContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(connecitonString);
            });


            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }


        public static void AddCustomSwaggerGenService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
    }
}
