using System.Globalization;
using ChatGPTClone.Application.Common.Interfaces;
using ChatGPTClone.WebApi.Services;
using Microsoft.AspNetCore.Localization;

namespace ChatGPTClone.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            //Localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Set the default culture

                var defaultCulture = new CultureInfo("tr-TR");

                // Set supported cultures

                var supportedCultures = new List<CultureInfo>
                {
                    defaultCulture,
                    new CultureInfo("en-GB")
                };

                // Add supported cultures
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);

                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;

                options.ApplyCurrentCultureToResponseHeaders = true;
            });

            return services;
        }
    }
}

// Dependency Inversion Principle (DIP) - Bağımlılıkların tersine çevrilmesi prensibi : Bağımlılıkların yüksek seviyeli modüllerden düşük seviyeli modüllere doğru olması gerektiğini belirtir. Yani yüksek seviyeli modüller düşük seviyeli modüllere bağımlı olmamalıdır. Her ikisi de soyutlamalara bağlı olmalıdır. Soyutlamalar detaylara bağlı olmamalıdır. Detaylar soyutlamalara bağlı olmalıdır.