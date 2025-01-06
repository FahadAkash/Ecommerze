var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Ecommerz_Server>("ecommerz-server");

builder.Build().Run();
