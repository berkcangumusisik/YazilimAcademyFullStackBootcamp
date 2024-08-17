using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Domain.Common;
using ChatGPTClone.Domain.Enums;
using ChatGPTClone.Domain.Identity;
using ChatGPTClone.Domain.ValueObjects;

namespace ChatGPTClone.Domain.Entities
{
    public sealed class ChatSession : EntityBase
    {
        public string Title { get; set; }
        public GptModelType Model { get; set; }
        // If the type is List in the entity then it is a ValueObject => Eğer tipi List ise bu bir ValueObject'dir.
        public List<ChatThread> Threads { get; set; } = [];
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // If the type is List is ICollection in the entity then it is an Entity => Eğer tipi ICollection ise bu bir Entity'dir.

    }
}

// sealed : Bu sınıfın başka bir sınıf tarafından kalıtım almasını engeller. Yani bu sınıfı başka bir sınıf kalıtım alamaz.