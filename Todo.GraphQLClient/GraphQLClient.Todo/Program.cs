using GraphQLClient.Todo;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

var serviceCollection = new ServiceCollection();

serviceCollection
        .AddTodoClient()
        .ConfigureHttpClient(client =>
        {
            client.BaseAddress = new Uri("https://apim-micro-services-dev.azure-api.net/graphql");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "YourSubscriptionKey");
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

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();
