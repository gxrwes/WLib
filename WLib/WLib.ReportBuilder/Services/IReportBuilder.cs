using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public interface IReportBuilder
    {
        Task<string> BuildHtmlReport();

    }
}
