namespace Microsoft.Extensions.DependencyInjection;

using BlazorTailwindUI.Services;

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
        services.AddSingleton<OcrEngineService>();
        services.AddSingleton<TwHydrationService>();
        services.AddSingleton<FullstackAgenticBridge>();
        services.AddSingleton<TwDonutCacheService>();
        services.AddSingleton<TwZstandardService>();
        services.AddSingleton<TwPostQuantumService>();
        services.AddSingleton<TwOpenTelemetryService>();

        return services;
    }
}
