dotnet new tool-manifest

dotnet tool install NSwag.ConsoleCore --version 14.0.1

dotnet nswag openapi2csclient /input:Data/swagger.json /classname:SpotifyService /namespace:SpotifyWeb /output:Data/SpotifyService.cs