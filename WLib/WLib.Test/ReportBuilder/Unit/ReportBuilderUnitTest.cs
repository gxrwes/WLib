using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WLib.ReportBuilder.Models;
using WLib.ReportBuilder.Services;

namespace WLib.Test.ReportBuilder.Unit
{
    [TestClass]
    public class ReportBuilderUnitTest
    {
        private Mock<ILogger<TestReportBuilder>> _loggerMock;
        private TestReportBuilder _reportBuilder;
        private TestReport _testReport;

        [TestInitialize]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<TestReportBuilder>>();

            // Create a sample TestReport with DateTime
            _testReport = new TestReport
            {
                ReportName = "Sample Test Report",
                ReportDate = DateTime.Now, // Using DateTime for the report date
                TestCases = new List<TestCase>
                {
                    new TestCase
                    {
                        TestName = "Test Case 1",
                        TestDescription = "This is a test case description.",
                        IsSuccess = true,
                        TestSteps = new List<TestStep>
                        {
                            new TestStep
                            {
                                StepName = "Step 1",
                                Details = "This is the first step.",
                                IsSuccess = true
                            },
                            new TestStep
                            {
                                StepName = "Step 2",
                                Details = "This is the second step.",
                                IsSuccess = false
                            }
                        }
                    },
                    new TestCase
                    {
                        TestName = "Test Case 2",
                        TestDescription = "This is another test case description.",
                        IsSuccess = false,
                        TestSteps = new List<TestStep>
                        {
                            new TestStep
                            {
                                StepName = "Step 1",
                                Details = "This is the only step.",
                                IsSuccess = false
                            }
                        }
                    }
                }
            };

            _reportBuilder = new TestReportBuilder(_loggerMock.Object, _testReport);
        }

        [TestMethod]
        public async Task BuildHtmlReport_ReturnsValidHtml()
        {
            // Act
            var result = await _reportBuilder.BuildHtmlReport();

            // Assert
            Assert.IsTrue(result.Contains("<html>"));
            Assert.IsTrue(result.Contains($"<h1>{_testReport.ReportName}</h1>"));
            Assert.IsTrue(result.Contains($"<p>Generated on: {_testReport.ReportDate}"));
            Assert.IsTrue(result.Contains("Test Case 1"));
            Assert.IsTrue(result.Contains("Step 1"));
            Assert.IsTrue(result.Contains("Status: <span class='success'>Passed</span>"));
            Assert.IsTrue(result.Contains("Status: <span class='fail'>Failed</span>"));

            // Verify that logger was called for building and completing the report
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Building HTML report for:")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);

            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("HTML report built successfully.")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }
    }
}
