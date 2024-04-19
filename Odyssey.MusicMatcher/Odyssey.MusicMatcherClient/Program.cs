using Microsoft.Extensions.DependencyInjection;
using Odyssey.MusicMatcherClient;
using StrawberryShake;
using System.Net.Http.Headers;

var serviceCollection = new ServiceCollection();

serviceCollection
        .AddMusicMatcherClientSvc()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5032/graphql");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

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
