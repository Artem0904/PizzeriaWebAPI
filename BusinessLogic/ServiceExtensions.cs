﻿using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            // enable user-side validation
            services.AddFluentValidationClientsideAdapters();
            // Load an assembly reference rather than using a marker type.
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPizzaService, PizzasService>();
            services.AddScoped<IBeverageService, BeveragesService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
