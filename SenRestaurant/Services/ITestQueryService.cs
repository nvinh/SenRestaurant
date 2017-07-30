using System.Threading.Tasks;

namespace Todo
{
    public interface ITestQueryService
    {
        Task<string> TestQueryAsync(string text);
    }
}
