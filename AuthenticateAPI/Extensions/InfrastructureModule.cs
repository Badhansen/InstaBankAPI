﻿namespace AuthenticateAPI.Extensions;

public static class InfrastructureModule
{
    public static void AddInfrastructureModule(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDatabaseDependencyInjection();
        service.AddFluentValidationDependencyInjection();
        service.AddDependencyInjectionRepositories();
        service.AddDependencyInjectionJwt(configuration);
    }
}