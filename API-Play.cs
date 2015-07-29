namespace TDC.Api.Controllers.v1
{
    public class PlayV1Controller : BaseController
    {
        [HttpPost]
        public HttpResponseMessage Post(PlayInput data)
        {
            var account = base.SuperplayerRequestContext.Account;
            var now = DateTime.Now.EnsureAsUtc().ClearSeconds().ClearMilliSeconds();

            var geolocation = base.GeoCoordenate;
            try
            {
                var result = new TrackProjectionWrapper
                {
                    Tracks = GetTracks(data.PlaylistsId, account, now, geolocation),
                };
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            finally
            {
                SavePlayedPlaylists(data.PlaylistsId, account, geolocation);
            }
        }


        private void SavePlayedPlaylists(
            long[] playlistsId,
            Account account,
            ApiGeoCoordenate geoLocation)
        {
            if (!AppSettings.PlaySaveTrack)
            {
                return;
            }

            try
            {
                //...

                var taskPlay = _beetService.Play.Post(data);
                if (account != null)
                {
                    taskPlay.ContinueWith(task => _beetService.Suggestion.Post(account.Id));
                }
            }
            catch
            {
				//log
            }
        }

        private List<TrackProjection> GetTracks(
            IEnumerable<long> playlistsId,
            Account account,
            DateTime now,
            ApiGeoCoordenate geoCoordenate)
        {
            var isPremium = account != null && account.Type == AccountType.Premium;

            var addSpots = !isPremium;

            var songs = new List<SongProjection>();
            var spots = new List<SpotProjection>();

            foreach (var playlist in playlists)
            {
                songs.AddRange(GetSongs(playlist, trackVersion));

                if (addSpots)
                {
                    spots.AddRange(GetSpots(playlist, now, locations));
                }
            }

            var result = JoinSongsAndSpots(songs, spots);
            return result;
        }
    }
}
