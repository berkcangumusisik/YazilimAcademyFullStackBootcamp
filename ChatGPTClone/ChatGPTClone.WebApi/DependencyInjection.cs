using ChatGPTClone.Application.Common.Interfaces;
using ChatGPTClone.Infrastructure.Persistence.Contexts;
using ChatGPTClone.WebApi.Services;

namespace ChatGPTClone.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserManager>();
            return services;
        }
    }
}

// Dependency Inversion Principle (DIP) - Bağımlılıkların tersine çevrilmesi prensibi : Bağımlılıkların yüksek seviyeli modüllerden düşük seviyeli modüllere doğru olması gerektiğini belirtir. Yani yüksek seviyeli modüller düşük seviyeli modüllere bağımlı olmamalıdır. Her ikisi de soyutlamalara bağlı olmalıdır. Soyutlamalar detaylara bağlı olmamalıdır. Detaylar soyutlamalara bağlı olmalıdır.