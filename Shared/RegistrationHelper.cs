using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Test;

public static class RegistrationHelper
{
    public static ServiceProvider BuildProvider(Dictionary<string, string> configValues)
    {
        var config = new ConfigurationBuilder()
                                        .AddInMemoryCollection(configValues!)
                                        .Build();

        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(config);

        services.AddOptions<PassthroughOptions>()
            .Configure<IConfiguration>((settings, config) => config
                .GetSection("Base")
                .GetSection(nameof(PassthroughOptions))
                .Bind(settings))
            .PostConfigure(settings =>
            {
                // set default values
                settings.Headers.Add("CorrelationId");
            });

        return services.BuildServiceProvider();
    }
}