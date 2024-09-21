using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatGPTClone.Application.Common.Models.OpenAI;

namespace ChatGPTClone.Application.Common.Interfaces
{
    public interface IOpenAiService
    {
        Task<OpenAIChatResponse> ChatAsync(OpenAIChatRequest request, CancellationToken cancelattionToken);
    }
}
