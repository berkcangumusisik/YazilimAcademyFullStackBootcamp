using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Application.Common.Interfaces;
using ChatGPTClone.Domain.Entities;

namespace ChatGPTClone.Application.Features.ChatSessions.Commands
{
    public class ChatSessionService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ChatSessionService(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task CreateChatSessionAsync(ChatSession chatSession, CancellationToken cancellationToken)
        {
            _applicationDbContext.ChatSessions.Add(chatSession);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }


    }
}
