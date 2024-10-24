﻿using EducationalPlatform.Infrastructure.Abstracts;
using EducationalPlatform.Infrastructure.Bases;
using EducationalPlatform.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EducationalPlatform.Infrastructure
{
    public static class InfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IContentRepository, ContentRepository>();
            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IQuizQuestionRepository, QuizQuestionRepository>();
            services.AddTransient<ICourseContentRepository, CourseContentRepository>();

            services.AddTransient<ISubmitRepository, SubmitRepository>();
            services.AddTransient<IQuizQuestionAnswerRepository, QuizQuestionAnswerRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();



            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
