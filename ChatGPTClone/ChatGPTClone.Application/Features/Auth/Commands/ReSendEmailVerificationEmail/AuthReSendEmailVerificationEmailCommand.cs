using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Application.Common.Models.General;
using MediatR;

namespace ChatGPTClone.Application.Features.Auth.Commands.ReSendEmailVerificationEmail
{
    public class AuthReSendEmailVerificationEmailCommand : IRequest<ResponseDto<string>>
    {
        public string Email { get; set; }

        public AuthReSendEmailVerificationEmailCommand(string email)
        {
            Email = email;
        }
    }
}
