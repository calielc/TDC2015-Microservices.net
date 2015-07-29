namespace Superplayer.BeetSDK
{
    public interface IPlaylistAgent
    {
        bool Put(long playlistId);

        bool Delete(long playlistId);
    }
}
