namespace Superplayer.Beet.PlaylistAgent
{
    public class Module : NancyModule
    {
        public Module()
        {
            Put["/{playlistId}"] = _ =>
            {
                this.RequiresAuthentication();

                var playlistId = (long)_.playlistId;

                playlistIntegrationService.Refresh(playlistId);

                var result = apiPlaylistRepository.FindBySourceId(playlistId);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK)
                    .WithModel(result);
            };


            Delete["/{playlistId}"] = _ =>
            {
                this.RequiresAuthentication();

                var playlistId = (long)_.playlistId;

                playlistIntegrationService.Delete(playlistId);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}
