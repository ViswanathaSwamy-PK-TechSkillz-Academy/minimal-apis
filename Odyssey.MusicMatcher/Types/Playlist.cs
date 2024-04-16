namespace Odyssey.MusicMatcher.Types;

public class Playlist
{
    [ID]
    public string Id { get; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
