﻿
using Catstagram_Server.Data;
using Catstagram_Server.Data.Models;
using Catstagram_Server.Features.Cats;
using Catstagram_Server.Features.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace Catstagram_Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            var ApplicationSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(ApplicationSettingsConfig);
            return ApplicationSettingsConfig.Get<AppSettings>();



        }
        public static IServiceCollection AddDatabase(
             this IServiceCollection services,
             IConfiguration configuration
            )
        => services
            .AddDbContext<CatstagramDbContext>( options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IServiceCollection AddIdenentity(this IServiceCollection services)
        {
            services
                    .AddIdentity<User, IdentityRole>(
                        options =>
                        {
                            options.Password.RequiredLength = 6;
                            options.Password.RequireDigit = false;
                            options.Password.RequireLowercase = false;
                            options.Password.RequireNonAlphanumeric = false;
                            options.Password.RequireUppercase = false;
                        })
                    .AddEntityFrameworkStores<CatstagramDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            AppSettings appSettings)
        {
          

            
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.secret);

            services.AddAuthentication(
               x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })


              .AddJwtBearer(
               x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });




            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        
            =>services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ICatService, CatServices>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
           return services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "My Catsgaram API",Version="v1" });
            });
        }
    }
        
     


    
}
