using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLib.ReportBuilder.Models;
using WLib.Util.Services;

namespace WLib.ReportBuilder.Services
{
    public class TestReportBuilder : IReportBuilder
    {
        private readonly ILogger<TestReportBuilder> _logger;
        private readonly TestReport _report;

        public TestReportBuilder(ILogger<TestReportBuilder> logger, TestReport report)
        {
            _logger = logger;
            _report = report;
        }

        public async Task<string> BuildHtmlReport()
        {
            _logger.LogInformation("Building HTML report for: {ReportName}", _report.ReportName);

            var sb = new StringBuilder();

            // Start HTML
            sb.AppendLine("<html>");
            sb.AppendLine("<head><style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; background-color: #333; color: #fff; }");
            sb.AppendLine(".container { padding: 20px; }");
            sb.AppendLine(".test-case { border: 1px solid #777; margin: 10px; padding: 10px; }");
            sb.AppendLine(".test-step { padding: 5px 20px; border: 1px solid #999; margin: 5px 0; }");
            sb.AppendLine(".collapsible { background-color: #555; color: #fff; cursor: pointer; padding: 10px; width: 100%; border: none; text-align: left; outline: none; }");
            sb.AppendLine(".collapsible:after { content: '\\002B'; font-size: 13px; float: right; }");
            sb.AppendLine(".active:after { content: '\\2212'; }");
            sb.AppendLine(".content { padding: 0 18px; display: none; background-color: #777; margin: 10px 0; }");
            sb.AppendLine(".success { color: lightgreen; } .fail { color: red; }");
            sb.AppendLine("</style></head>");
            sb.AppendLine("<body>");
            sb.AppendLine($"<h1>{_report.ReportName}</h1>");
            sb.AppendLine($"<p>Generated on: {_report.ReportDate}</p>");
            sb.AppendLine("<div class='container'>");

            foreach (var testCase in _report.TestCases)
            {
                // Test case header
                sb.AppendLine($"<div class='test-case'><h2>{testCase.TestName}</h2>");
                sb.AppendLine($"<p>{testCase.TestDescription}</p>");
                sb.AppendLine($"<p>Status: {(testCase.IsSuccess ? "<span class='success'>Passed</span>" : "<span class='fail'>Failed</span>")}</p>");

                // Test steps (collapsible)
                sb.AppendLine("<button class='collapsible'>Show/Hide Test Steps</button>");
                sb.AppendLine("<div class='content'>");

                foreach (var step in testCase.TestSteps)
                {
                    sb.AppendLine($"<div class='test-step'><p><strong>{step.StepName}</strong></p>");
                    sb.AppendLine($"<p>{step.Details}</p>");
                    sb.AppendLine($"<p>Status: {(step.IsSuccess ? "<span class='success'>Passed</span>" : "<span class='fail'>Failed</span>")}</p>");
                    sb.AppendLine("</div>");
                }

                sb.AppendLine("</div></div>");
            }

            sb.AppendLine("</div>");

            // Collapsible Script
            sb.AppendLine("<script>");
            sb.AppendLine("var coll = document.getElementsByClassName('collapsible');");
            sb.AppendLine("for (var i = 0; i < coll.length; i++) {");
            sb.AppendLine("coll[i].addEventListener('click', function() {");
            sb.AppendLine("this.classList.toggle('active');");
            sb.AppendLine("var content = this.nextElementSibling;");
            sb.AppendLine("if (content.style.display === 'block') { content.style.display = 'none'; }");
            sb.AppendLine("else { content.style.display = 'block'; } }); }");
            sb.AppendLine("</script>");

            sb.AppendLine("</body></html>");

            _logger.LogInformation("HTML report built successfully.");

            // Simulating async operation
            return await Task.FromResult(sb.ToString());
        }
    }
}
