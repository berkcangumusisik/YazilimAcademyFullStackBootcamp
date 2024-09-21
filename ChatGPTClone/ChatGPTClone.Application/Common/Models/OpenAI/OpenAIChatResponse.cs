using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTClone.Application.Common.Models.OpenAI
{
    public class OpenAIChatResponse
    {
        public string Response { get; set; }

        public OpenAIChatResponse(string response)
        {
            Response = response;
        }
    }
}
