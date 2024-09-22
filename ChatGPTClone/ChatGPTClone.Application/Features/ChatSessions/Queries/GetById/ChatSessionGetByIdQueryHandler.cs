using ChatGPTClone.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ChatGPTClone.Application.Features.ChatSessions.Queries.GetById
{
    public sealed class ChatSessionGetByIdQueryHandler : IRequestHandler<ChatSessionGetByIdQuery, ChatSessionGetByIdDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;

        // Bu, önbellekte saklanan verileri tanımlamak için kullanılan anahtar dizesidir.
        private const string CacheKey = "ChatSessionGetAll_";

        // Bu, önbellek girdilerinin nasıl saklanacağını ve yönetileceğini belirleyen seçenekler nesnesidir.
        private readonly MemoryCacheEntryOptions _cacheOptions;

        // Bu, sınıfın yapıcı metodudur. Gerekli bağımlılıkları enjekte eder.
        public ChatSessionGetByIdQueryHandler(
            IApplicationDbContext context,
            ICurrentUserService currentUserService,
            IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;

            // Önbellek seçeneklerini ayarlar. Burada, önbellek girdisinin 1 saat sonra sona ereceği ve yüksek öncelikli olduğu belirtilir.
            _cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromHours(1))
            .SetPriority(CacheItemPriority.High);
        }


        public async Task<ChatSessionGetByIdDto> Handle(ChatSessionGetByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"{CacheKey}{request.Id}";
            if (_memoryCache.TryGetValue(cacheKey, out ChatSessionGetByIdDto cachedResult))
            {
                return cachedResult;
            }
            var chatSession = await _context.ChatSessions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var chatSessionGetByIdDto = ChatSessionGetByIdDto.MapFromChatSession(chatSession);

            _memoryCache.Set(cacheKey, chatSessionGetByIdDto, _cacheOptions);

            return chatSessionGetByIdDto;
        }

    }
}