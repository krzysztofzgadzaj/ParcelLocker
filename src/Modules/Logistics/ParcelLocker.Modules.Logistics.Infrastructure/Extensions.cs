﻿using Microsoft.Extensions.DependencyInjection;

namespace ParcelLocker.Modules.Logistics.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        => serviceCollection;
}
