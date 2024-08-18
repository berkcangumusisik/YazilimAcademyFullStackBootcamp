using ChatGPTClone.Domain.Common;
using ChatGPTClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ChatGPTClone.Domain.Identity;

public class AppUser : IdentityUser<Guid>, IEntity, ICreatedByEntity, IModifiedByEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public string CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
    public string? ModifiedByUserId { get; set; }
    public ICollection<ChatSession> ChatSessions { get; set; }
}


/*
 * Identity kütüphanesinde SecurityStamp ve ConcurrencyStamp alanları bulunmaktadır. Bu alanlar, kullanıcı bilgilerinin güvenliğini sağlamak için kullanılmaktadır.
 * SecurityStamp : Kullanıcı bilgilerinin güvenliğini sağlamak için kullanılan bir alandır. Kullanıcı bilgileri değiştiğinde bu alan da güncellenir. Güvenlik saldırılarına karşı koruma sağlar.  Şifre değiştiğinde yeniden login yapılmasını sağlar. 30 dakikada bir güncellenir.
 * ConcurrencyStamp : Eşzamanlılık denetimi için kullanılan bir alandır. Kullanıcı bilgileri üzerinde yapılan değişikliklerin eşzamanlı olarak kontrol edilmesini sağlar.
 * Hash : Geri döndürülemez bir şekilde data bozulur.Kullanıcı değiştirmek istediğinde, eski veriyi hashleyip, yeni veriyle karşılaştırarak, aynı olup olmadığını kontrol ederiz. Geriye dönüşü olmayan bir işlemdir.
 * Encyrption : Belirli bir mantığa ve algoritmayla şifrelenen data, aynı mantık ve algoritma ile çözülebilir. Data bozulmaz. Veri gizliliği sağlar.
 */