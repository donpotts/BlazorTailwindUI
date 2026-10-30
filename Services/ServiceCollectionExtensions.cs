namespace Microsoft.Extensions.DependencyInjection;

using BlazorTailwindUI.Models;
using BlazorTailwindUI.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class BlazorTailwindUIServiceExtensions
{
    /// <summary>
    /// Registers all Blazor Tailwind UI core services including Theme, Audio FX, PWA, Form Engine, and Tool Registry.
    /// </summary>
    public static IServiceCollection AddBlazorTailwindUI(this IServiceCollection services)
    {
        services.AddScoped<ThemeService>();
        services.AddScoped<ToastService>();
        services.AddScoped<TwSoundService>();
        services.AddScoped<TwPwaService>();
        services.AddSingleton<ComponentCatalogService>();
        services.AddSingleton<FormCatalogService>();
        services.AddSingleton<AgenticToolRegistry>();
        services.AddScoped<OcrEngineService>();
        services.AddSingleton<TwHydrationService>();
        services.AddSingleton<FullstackAgenticBridge>();
        services.AddSingleton<TwDonutCacheService>();
        services.AddSingleton<TwZstandardService>();
        services.AddSingleton<TwPostQuantumService>();
        services.AddSingleton<TwOpenTelemetryService>();
        services.AddSingleton<TwSimdVectorService>();
        services.AddScoped<TwAspireService>();
        services.AddScoped<ServerPortBridgeService>();
        // Default offline agent; register your own IAgentTransport before this call to drive a live agent.
        services.TryAddScoped<IAgentTransport, SimulatedAgentTransport>();

        return services;
    }
}
