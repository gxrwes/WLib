using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wazorize.Models
{
    public class Project : Content
    {
        public Project()
        {
            Type = "Project";
        }

        public ProjectTypes ProjectType { get; set; }

        public string PreviewImage { get; set; } = string.Empty;
        public string BackgroundImage { get; set; } = string.Empty;
        public string BlogPostTitle { get; set; } = string.Empty;
        public string BlogPostSubtitle { get; set; } = string.Empty;
        public string BlogPostDate { get; set; } = string.Empty;
        public string BlogPostAuthor { get; set; } = string.Empty;
        public List<BlogPostContent> BlogPostContent { get; set; } = new List<BlogPostContent>();
        public bool ShowBlogPost { get; set; } = true;
        public string GitHubRepoUrl { get; set; } = string.Empty;
        public string GitHubRepoName { get; set; } = string.Empty;
        public string GitHubRepoAuthor { get; set; } = string.Empty;
        public bool ShowGitHubRepo { get; set; } = true;
        public List<StringTouple> Images { get; set; } = new List<StringTouple>();
    }
}
