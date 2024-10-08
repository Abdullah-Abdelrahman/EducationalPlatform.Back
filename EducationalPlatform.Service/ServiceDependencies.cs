﻿using EducationalPlatform.Service.Abstracts;
using EducationalPlatform.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EducationalPlatform.Service
{
    public static class ServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();

            services.AddTransient<IAnswerService, AnswerService>();


            return services;
        }
    }
}
