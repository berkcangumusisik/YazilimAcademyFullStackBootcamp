using Microsoft.EntityFrameworkCore;
using PasswordStorageApp.WebApi.Models;
using PasswordStorageApp.WebApi.Persistence.Configurations;

namespace PasswordStorageApp.WebApi.Persistence.Contexts
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new AccountConfiguration()); //AccountConfiguration sınıfı ile Account sınıfı eşleştirilir. Ama bu işlemi yapmak yerine ApplyConfigurationsFromAssembly metodu ile tüm sınıfların eşleştirilmesi sağlanabilir. Diğer türlü her sınıf için ayrı ayrı eşleştirme yapılması gerekir.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); // Bu metot ile tüm sınıfların eşleştirilmesi sağlanır.
        }
    }
}

/*
 * DbContext fazla veri olduğunda performans sorunlarına yol açabilir. Performansı artırmak için farklı DbContext'ler oluşturabiliriz.
 * Entity veritabanı tablolarını temsil eden sınıflardır.
 * Fluent API, Entity Framework Core'da veritabanı tablolarını oluştururken kullanılan bir API'dir. Fluent API, veritabanı tablolarını oluştururken daha fazla kontrol sağlar.
 
 */