using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTClone.Domain.Common
{
    public abstract class EntityBase : IEntity, ICreatedByEntity, IModifiedByEntity
    {
        public virtual Guid Id { get; set; }

        public virtual DateTimeOffset CreatedOn { get; set; }
        public virtual string CreatedByUserId { get; set; }

        public virtual DateTimeOffset? ModifiedOn { get; set; }
        public virtual string ModifiedByUserId { get; set; }
    }
}


//virtual : Bu özelliğin ezilebileceğini belirtir. Bu, türetilmiş sınıfların bu özelliği geçersiz kılmasına izin verir.