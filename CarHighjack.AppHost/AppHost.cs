using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<CarHighjack_Presentation>("api");
//.WithHealthCheck("/health");

// Frontend — Vite dev server
builder.AddNpmApp("frontend", "../CarHighjack.Frontend", "dev")
    .WithReference(api)
    .WithExternalHttpEndpoints()
    .WithEnvironment("VITE_API_URL", api.GetEndpoint("http"));

builder.Build().Run();
