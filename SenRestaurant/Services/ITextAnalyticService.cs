using System.Threading.Tasks;

namespace Todo
{
    public interface ITextAnalyticService
    {
        Task<string> AnalyticTextAsync(string text);
    }
}
