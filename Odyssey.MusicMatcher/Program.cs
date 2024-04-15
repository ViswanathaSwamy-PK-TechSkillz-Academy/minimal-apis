using Odyssey.MusicMatcher.Types;
using System.Buffers.Text;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/api", () => "Hello World!");

// /graphql
app.MapGraphQL();
app.Run();


// 1.annotation - based, 2. code - first, and 3. schema-first.