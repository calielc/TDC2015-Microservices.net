using System.Threading.Tasks;

namespace Superplayer.BeetSDK
{
    public interface ISuggestionAgent
    {
        Task<bool> Post(long accountId);
    }
}
