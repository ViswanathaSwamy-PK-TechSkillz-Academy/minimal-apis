// 1.annotation - based, 2. code - first, and 3. schema-first.
// Reference: https://www.apollographql.com/tutorials/intro-hotchocolate/05-apollo-explorer
// Reference: https://graphql.org/learn/
// Reference: https://studio.apollographql.com/org/viswanatha-swamys-team/graphs
// Reference: https://studio.apollographql.com/sandbox/explorer
// Reference: https://github.com/apollographql-education/odyssey-intro-hotchocolate

dotnet new tool-manifest

dotnet tool install NSwag.ConsoleCore --version 14.0.1

dotnet nswag openapi2csclient /input:Data/swagger.json /classname:SpotifyService /namespace:SpotifyWeb /output:Data/SpotifyService.cs

dotnet graphql init https://apim-micro-services-dev.azure-api.net/graphql -n ToDoClient -p .

dotnet graphql init https://apim-micro-services-dev.azure-api.net/graphql/ -n ToDoClient -p . -x ocp-apim-subscription-key=YourKey -x Content-Type=application/json

dotnet graphql init http://localhost:5032/graphql/ -n ToDoClient -p ./MusicClient

PS D:\TSA\minimal-apis\GraphQL.ToDos> dotnet graphql init https://apim-micro-services-dev.azure-api.net/graphql/ -n ToDoClient -p . -x ocp-apim-subscription-key=YourSubscriptionKey -x Content-Type=application/json
Download schema started.
error INTROSPECTION_ERROR: Internal Execution Error