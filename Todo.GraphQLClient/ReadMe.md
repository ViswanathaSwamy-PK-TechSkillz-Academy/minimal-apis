# Title

## Sub Title 1

```powershell
dotnet new sln --name Todo.GraphQLClient

dotnet new console -n GraphQLClient.Todo

dotnet sln add ./GraphQLClient.Todo

dotnet add ./GraphQLClient.Todo package StrawberryShake.Server
dotnet add ./GraphQLClient.Todo package StrawberryShake.Transport.Http

dotnet graphql init https://apim-micro-services-dev.azure-api.net/graphql -n TodoClient -p ./GraphQLClient.Todo --headers ocp-apim-subscription-key=YourKey --headers Content-Type=application/json
```
