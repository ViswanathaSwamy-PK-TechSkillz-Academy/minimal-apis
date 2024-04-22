namespace Odyssey.MusicMatcherGQL.Types;

using Microsoft.AspNetCore.Mvc;
using SpotifyWeb;

public class Query
{
    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public async Task<List<Playlist>> FeaturedPlaylists([FromServices] SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();

        return response.Playlists.Items.Select(item => new Playlist(item)).ToList();
    }
}