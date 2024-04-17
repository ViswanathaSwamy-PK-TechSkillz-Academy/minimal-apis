using Odyssey.MusicMatcherGQL.Types;
using SpotifyWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<SpotifyService>();

builder.Services.AddGraphQLServer()
      .AddQueryType<Query>()
      .RegisterService<SpotifyService>();

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


