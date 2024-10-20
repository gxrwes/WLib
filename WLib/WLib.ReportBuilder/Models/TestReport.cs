using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLib.ReportBuilder.Models
{
    public class TestReport
    {
        public string ReportName { get; set; }
        public List<TestCase> TestCases { get; set; } = new List<TestCase>();
        public DateTime ReportDate { get; set; } = DateTime.Now;
    }
}
