using GraphQLClient.Todo;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
        .AddTodoClient()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("https://apim-micro-services-dev.azure-api.net/graphql");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "980c6e56098f44ffa6125256c75ed2b0");
        });

IServiceProvider services = serviceCollection.BuildServiceProvider();

ITodoClient client = services.GetRequiredService<ITodoClient>();

var result = await client.TodoItems.ExecuteAsync();
result.EnsureNoErrors();

ForegroundColor = ConsoleColor.DarkCyan;

foreach (var todoItem in result?.Data?.TodoItems!)
{
    WriteLine($"Id: {todoItem.Id} \nTitle: {todoItem.Title} \nCompleted: {todoItem.Completed}\n");
}

var output = await client.GetTodoById.ExecuteAsync("6");
foreach (var todoItem in output?.Data?.GetTodoById!)
{
    WriteLine($"Id: {todoItem.Id} \nTitle: {todoItem.Title} \nCompleted: {todoItem.Completed}\n");
}

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();
