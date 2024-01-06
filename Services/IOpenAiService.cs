using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenAI_with_.Net.Services
{
    public interface IOpenAiService
    {
        Task<string> CompleteSentence(string text);
        
    }
}