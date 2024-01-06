using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAI_API.Completions;
using OpenAI_with_.Net.Configurations;

namespace OpenAI_with_.Net.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly OpenAiConfig _openAiConfig;

        public OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor)
        {
            _openAiConfig = optionsMonitor.CurrentValue;
        }
        public async Task<string> CompleteSentence(string text)
        {
            string answer = string.Empty;
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = text;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 200;
            var result = await api.Completions.CreateCompletionAsync(completion);

            foreach (var item in result.Completions)
            {
                answer = item.Text;
            }
            return answer;
        }
    }
}