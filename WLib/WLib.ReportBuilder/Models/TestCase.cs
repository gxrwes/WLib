using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLib.ReportBuilder.Models
{
    public class TestCase
    {
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public List<TestStep> TestSteps { get; set; } = new List<TestStep>();
        public bool IsSuccess { get; set; }
    }
}
