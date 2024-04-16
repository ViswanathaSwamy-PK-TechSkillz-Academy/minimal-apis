namespace Odyssey.MusicMatcher.Types;

public class Query
{
    // where Query resolver functions will go

    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public List<Playlist> FeaturedPlaylists()
    {
        return
        [
           new Playlist("1", "GraphQL Groovin'"),
           new Playlist("2", "Graph Explorer Jams"),
           new Playlist("3", "Interpretive GraphQL Dance")
        ];
    }
}

