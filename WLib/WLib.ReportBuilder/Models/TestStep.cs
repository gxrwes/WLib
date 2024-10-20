using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLib.ReportBuilder.Models
{
    public class TestStep
    {
        public string StepName { get; set; }
        public string Details { get; set; }
        public bool IsSuccess { get; set; }
    }
}
