using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordStorageApp.WebApi.Enums;
using PasswordStorageApp.WebApi.Models;

namespace PasswordStorageApp.WebApi.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>

    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // ID 
            builder.HasKey(x => x.Id); //.HasKey ile primary key belirtilir.
            builder.Property(x => x.Id).ValueGeneratedOnAdd(); //.ValueGeneratedOnAdd ile primary key'in otomatik artan olduğu belirtilir.

            // Username
            builder.Property(x => x.Username).IsRequired().HasMaxLength(50); //.IsRequired ile alanın zorunlu olduğu belirtilir. .HasMaxLength ile alanın maksimum uzunluğu belirtilir.
            builder.HasIndex(x => x.Username); //.HasIndex ile alanın index olduğu belirtilir ve bu indexe göre arama yapılabilir. .IsUnique ile alanın unique olduğu belirtilir.

            // Password
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
            
            // Type
            builder.Property(x => x.Type).HasConversion<int>().HasDefaultValue(AccountType.Web).IsRequired(); //.HasConversion ile enum'un int'e çevrildiği belirtilir. .HasDefaultValue ile alanın varsayılan değeri belirtilir.

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired(false); 

            // ModifiedOn
            builder.Property(x => x.ModifiedOn); 

            // Table Name
            builder.ToTable("Accounts"); //.ToTable ile tablo adı belirtilir.

        }
    }
}
