// 1.annotation - based, 2. code - first, and 3. schema-first.
// Reference: https://www.apollographql.com/tutorials/intro-hotchocolate/05-apollo-explorer
// Reference: https://graphql.org/learn/
// Reference: https://studio.apollographql.com/org/viswanatha-swamys-team/graphs
// Reference: https://studio.apollographql.com/sandbox/explorer
// Reference: https://github.com/apollographql-education/odyssey-intro-hotchocolate

dotnet new tool-manifest

dotnet tool install NSwag.ConsoleCore --version 14.0.1

dotnet nswag openapi2csclient /input:Data/swagger.json /classname:SpotifyService /namespace:SpotifyWeb /output:Services/SpotifyService.cs