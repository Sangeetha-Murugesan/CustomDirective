using HotChocolate.Execution;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddTypes();

var app = builder.Build();

var executor = await app.Services.GetRequestExecutorAsync();

await File.WriteAllTextAsync("schema.graphql", executor.Schema.ToString());

app.MapGraphQL();

app.RunWithGraphQLCommands(args);


