using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

var graphQlEndPoint = "https://apim-micro-services-dev.azure-api.net/graphql";

var options = new GraphQLHttpClientOptions
{
    EndPoint = new Uri(graphQlEndPoint),
    MediaType = "application/json",
};

var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(graphQlEndPoint);
httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "c3517062ef2c42b8bc94f728d597c7dc");

using var graphQlClient = new GraphQLHttpClient(options, new NewtonsoftJsonSerializer(), httpClient);

// Define your GraphQL query
var query = @"
    query TodoItems {
        todoItems {
            id
            title
            completed
            userId
        }
    }
";

// Create a GraphQL request object
var request = new GraphQLRequest
{
    Query = query
};

// Send the GraphQL request using the client
var response = await graphQlClient.SendQueryAsync<dynamic>(request);

Console.WriteLine(response.Data.todoItems);