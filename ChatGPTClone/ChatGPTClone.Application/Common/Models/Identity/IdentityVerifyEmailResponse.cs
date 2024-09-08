using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTClone.Application.Common.Models.Identity
{
    public class IdentityVerifyEmailResponse
    {
        public string Email { get; set; }

        public IdentityVerifyEmailResponse(string email)
        {
            Email = email;
        }
    }
}
