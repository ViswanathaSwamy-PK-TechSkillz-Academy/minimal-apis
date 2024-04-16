using Odyssey.MusicMatcher.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<Playlist>();

builder.Services
   .AddCors(options =>
   {
       options.AddDefaultPolicy(builder =>
       {
           builder
               .WithOrigins("https://studio.apollographql.com")
               .AllowAnyHeader()
               .AllowAnyMethod();
       });
   });

var app = builder.Build();

app.MapGet("/api", () => "Hello World!");

app.UseCors();

// /graphql
app.MapGraphQL();

app.Run();


// 1.annotation - based, 2. code - first, and 3. schema-first.
// Reference: https://www.apollographql.com/tutorials/intro-hotchocolate/05-apollo-explorer
// Reference: https://graphql.org/learn/
// Reference: https://studio.apollographql.com/org/viswanatha-swamys-team/graphs
// Reference: https://studio.apollographql.com/sandbox/explorer
// Reference: https://github.com/apollographql-education/odyssey-intro-hotchocolate