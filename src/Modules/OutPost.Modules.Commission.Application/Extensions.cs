﻿using Microsoft.Extensions.DependencyInjection;
using OutPost.Modules.Commission.Application.BackgroundProcessing;
using OutPost.Modules.Commission.Application.BackgroundProcessing.Jobs;

namespace OutPost.Modules.Commission.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        //serviceCollection.AddHostedService<OutpostConfigurationBackgroundService>();

        return serviceCollection;
    }
}
