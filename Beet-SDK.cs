namespace Superplayer.BeetSDK
{
    public interface IBeetService
    {
        ICategoryAgent Category { get; }

        ITabAgent Tab { get; }

        IPlaylistAgent Playlist { get; }

        ISpotAgent Spot { get; }

        ISponsorshipAgent Sponsorship { get; }

        IPlayAgent Play { get; }

        IHighlightAgent Highlight { get; }

        ISuggestionAgent Suggestion { get; }

        IAlfredAgent Alfred { get; }

        IFilterAgent Filter { get; }

        IPortalAgent Portal { get; }

        ITrackAgent Track { get; }

        INotificationAgent Notification { get; }

        IPlaylistRelationshipAgent PlaylistRelationship { get; }
    }
}
