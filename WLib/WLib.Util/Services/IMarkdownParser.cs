using System.Threading.Tasks;

namespace WLib.Util.Services
{
    public interface IMarkdownParser
    {
        Task<string> ParseToHtml(string markdownText);
    }
}
