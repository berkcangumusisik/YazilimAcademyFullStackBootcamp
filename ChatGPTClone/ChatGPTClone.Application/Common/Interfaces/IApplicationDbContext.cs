using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatGPTClone.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ChatSession> ChatSessions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}


// Dependency Inversion Principle (DIP): Yüksek seviye modüller, düşük seviye modüllere bağlı olmamalıdır. Her ikisi de soyutlamalara bağlı olmalıdır.