var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<Projects.BlazingBudget_WebApi>("webapi");

builder.AddProject<Projects.BlazingBudget>("webui")
	.WithReference(webApi);

builder.Build().Run();
