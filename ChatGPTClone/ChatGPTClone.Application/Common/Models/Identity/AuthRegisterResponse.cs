using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTClone.Application.Common.Models.Identity
{
    public class IdentityRegisterResponse
    {
        public Guid Id { get; set; }
        public string EmailToken { get; set; }

        public IdentityRegisterResponse(Guid id, string emailToken)
        {
            Id = id;
            EmailToken = emailToken;
        }
    }
}
