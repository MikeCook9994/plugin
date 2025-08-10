var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Plugin_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Plugin_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
