namespace Odyssey.MusicMatcherGQL.Types;

public class Artist(string id, string name)
{
    [ID]
    public string Id { get; } = id;

    public string Name { get; set; } = name;

    public int? Followers { get; set; }

    public float? Popularity { get; set; }
}
