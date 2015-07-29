using System.Threading.Tasks;
using Superplayer.BeetSDK.Models;

namespace Superplayer.BeetSDK
{
    public interface IPlayAgent
    {
        Task<bool> Post(PlayAgentData data);
    }
}
