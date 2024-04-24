using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.Extensions.DependencyInjection;

var graphQlEndPoint = "https://YourAPIMEndPoint.azure-api.net/graphql";

var options = new GraphQLHttpClientOptions
{
    EndPoint = new Uri(graphQlEndPoint),
    MediaType = "application/json",
};

var httpClient = new HttpClient
{
    BaseAddress = new Uri(graphQlEndPoint),
    DefaultRequestHeaders =
    {
        { "Ocp-Apim-Subscription-Key", "YourCode" }
    }
};

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