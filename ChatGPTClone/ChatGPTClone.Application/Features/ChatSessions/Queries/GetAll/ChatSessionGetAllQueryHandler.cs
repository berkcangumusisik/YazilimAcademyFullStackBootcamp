using ChatGPTClone.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ChatGPTClone.Application.Features.ChatSessions.Queries.GetAll
{
    public class ChatSessionGetAllQueryHandler : IRequestHandler<ChatSessionGetAllQuery, List<ChatSessionGetAllDto>>
    {
        // Bu, veritabanı işlemlerini gerçekleştirmek için kullanılan bağlam nesnesidir.
        private readonly IApplicationDbContext _context;

        // Bu, mevcut kullanıcının bilgilerini almak için kullanılan servistir.
        private readonly ICurrentUserService _currentUserService;

        // Bu, verileri önbellekte saklamak için kullanılan bellek önbelleği nesnesidir.
        private readonly IMemoryCache _memoryCache;

        // Bu, önbellekte saklanan verileri tanımlamak için kullanılan anahtar dizesidir.
        private const string CacheKey = "ChatSessionGetAll_";

        // Bu, önbellek girdilerinin nasıl saklanacağını ve yönetileceğini belirleyen seçenekler nesnesidir.
        private readonly MemoryCacheEntryOptions _cacheOptions;

        // Bu, sınıfın yapıcı metodudur. Gerekli bağımlılıkları enjekte eder.
        public ChatSessionGetAllQueryHandler(
            IApplicationDbContext context,
            ICurrentUserService currentUserService,
            IMemoryCache memoryCache)
        {
            _context = context;
            _currentUserService = currentUserService;
            _memoryCache = memoryCache;

            // Önbellek seçeneklerini ayarlar. Burada, önbellek girdisinin 1 saat sonra sona ereceği ve yüksek öncelikli olduğu belirtilir.
            _cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromHours(1))
            .SetPriority(CacheItemPriority.High);
        }

    


        // Bu metod, gelen sorguyu işler ve sonucu döndürür.
        public async Task<List<ChatSessionGetAllDto>> Handle(ChatSessionGetAllQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"{CacheKey}{_currentUserService.UserId}";
            if (_memoryCache.TryGetValue(cacheKey, out List<ChatSessionGetAllDto> cachedResult))
            {
                return cachedResult;
            }

            // Veritabanından sohbet oturumlarını alır.
            var chatSessions = await _context
                .ChatSessions
                .AsNoTracking() // Bu, Entity Framework'ün değişiklikleri izlememesini sağlar, böylece performans artar.
                .Where(x => x.AppUserId == _currentUserService.UserId) // Sadece mevcut kullanıcının oturumlarını filtreler.
                .OrderByDescending(cs => cs.CreatedOn) // Oturumları oluşturulma tarihine göre azalan sırada sıralar.
                .Select(x => ChatSessionGetAllDto.MapFromChatSession(x)) // Her oturumu DTO'ya dönüştürür.
                .ToListAsync(cancellationToken); // Sonuçları asenkron olarak bir liste halinde alır.

            _memoryCache.Set(cacheKey, chatSessions, _cacheOptions);

            return chatSessions;
        }
    }
}
