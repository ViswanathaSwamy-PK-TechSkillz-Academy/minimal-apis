using School.API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

_ = builder.Services.ConfigureDependedServices("Name=SchoolAppDbConnection");

var app = builder.Build();

app.ConfigureHttpRequestPipeline();

app.Run();

