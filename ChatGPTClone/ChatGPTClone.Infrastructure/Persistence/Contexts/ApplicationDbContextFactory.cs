using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ChatGPTClone.Infrastructure.Persistence.Contexts;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

// Bu sınıf, Entity Framework Core CLI tarafından tasarım zamanında bir veritabanı bağlamı oluşturmak için kullanılır.
// Bu sınıf, tasarım zamanında bir veritabanı bağlamı oluşturmak için kullanılır.
// dotnet ef migrations add : Bu komut, veritabanı şemasında bir değişiklik yapar ve bu değişikliği uygulamak için gerekli olan kodu oluşturur.
// dotnet ef migrations remove : Bu komut, en son oluşturulan migration'ı geri alır.
// dotnet ef migrations list : Bu komut, uygulanmış ve uygulanmamış migration'ları listeler.
// dotnet ef database update : Bu komut, uygulanmamış migration'ları veritabanına uygular.
// dotnet ef migrations add InitialCreate --startup-project ../ChatGPTClone.WebApi : Bu komut, InitialCreate adında bir migration oluşturur ve bu migration'ı belirtilen proje üzerinde çalıştırır.




