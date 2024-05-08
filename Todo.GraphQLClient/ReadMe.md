# Title

## Sub Title 1

```powershell
dotnet new sln --name Todo.GraphQLClient

dotnet new console -n GraphQLClient.Todo

dotnet sln add ./GraphQLClient.Todo

dotnet add ./GraphQLClient.Todo package StrawberryShake.Server
dotnet add ./GraphQLClient.Todo package StrawberryShake.Transport.Http

dotnet graphql init https://apim-micro-services-dev.azure-api.net/graphql -n TodoClient -p ./GraphQLClient.Todo --headers "Ocp-Apim-Subscription-Key=YourKey" --headers "Content-Type=application/json"

dotnet graphql init -n TodoClient -p ./GraphQLClient.Todo --headers "Ocp-Apim-Subscription-Key=YourKey" -x "content-type=application/json" https://apim-micro-services-dev.azure-api.net/graphql
```

@($"https://jsonplaceholder.typicode.com/users/1/todos?id={context.GraphQL.Arguments["id"]}")"
