using Markdig;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public class MarkdownParser : IMarkdownParser
    {
        private readonly MarkdownPipeline _pipeline;
        private readonly ILogger<MarkdownParser> _logger;

        public MarkdownParser(ILogger<MarkdownParser> logger)
        {
            // Create a Markdown pipeline with default extensions
            _pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> ParseToHtml(string markdownText)
        {
            _logger.LogInformation("Starting markdown parsing.");

            if (string.IsNullOrWhiteSpace(markdownText))
            {
                _logger.LogWarning("Received empty or null markdown text.");
                return string.Empty;
            }

            try
            {
                // Convert markdown to HTML using Markdig
                string html = Markdown.ToHtml(markdownText, _pipeline);
                _logger.LogInformation("Successfully parsed markdown text to HTML.");
                return html;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while parsing markdown.");
                throw;
            }
        }
    }
}
