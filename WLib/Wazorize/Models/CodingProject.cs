using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazorize.Models
{
    public class CodingProject : Project
    {
        public string GitRepoName { get; set; }
        public string GitRepoUrl { get; set; }
        public string Readme { get; set; }
        public CodingProject()
        {
            ProjectType = ProjectTypes.Coding;

        }
    }
}
