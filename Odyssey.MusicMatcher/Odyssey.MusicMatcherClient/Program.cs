using Microsoft.Extensions.DependencyInjection;
using Odyssey.MusicMatcherClient;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
        .AddMusicMatcherClientSvc()
        .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:5032/graphql"));

IServiceProvider services = serviceCollection.BuildServiceProvider();

IMusicMatcherClientSvc client = services.GetRequiredService<IMusicMatcherClientSvc>();

var result = await client.FeaturedPlaylists.ExecuteAsync();
result.EnsureNoErrors();

ForegroundColor = ConsoleColor.DarkCyan;

foreach (var playlist in result?.Data?.FeaturedPlaylists!)
{
    WriteLine($"Id: {playlist.Id} \nName: {playlist.Name} \nDescription: {playlist.Description}\n");
}

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();
