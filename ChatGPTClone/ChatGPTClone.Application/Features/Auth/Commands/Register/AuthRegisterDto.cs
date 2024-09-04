using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Application.Common.Models.Identity;

namespace ChatGPTClone.Application.Features.Auth.Commands.Register
{
    public class AuthRegisterDto
    {
        public Guid Id { get; set; }
        public string EmailToken { get; set; }

        public AuthRegisterDto(Guid id, string emailToken)
        {
            Id = id;
            EmailToken = emailToken;
        }

        public static AuthRegisterDto Create(IdentityRegisterResponse response)
        {
            return new AuthRegisterDto(response.Id, response.EmailToken);
        }
    }
}
