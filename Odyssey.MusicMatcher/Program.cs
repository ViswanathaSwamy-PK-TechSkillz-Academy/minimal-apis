using Odyssey.MusicMatcher.Types;

var builder = WebApplication.CreateBuilder(args);

// Reference: https://www.apollographql.com/tutorials/intro-hotchocolate/05-apollo-explorer

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

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