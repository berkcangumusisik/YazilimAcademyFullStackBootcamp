using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChatGPTClone.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly((Assembly.GetExecutingAssembly()));

                //Validation Pipeline 
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); // Bu eklenen satır, ValidationBehaviour'ı MediatR pipeline'a ekler. , bir placeholderdır. Runtime'da bu placeholder, IPipelineBehavior'ın generic parametrelerine dönüşür.

            });
            return services;
        }
    }
}
