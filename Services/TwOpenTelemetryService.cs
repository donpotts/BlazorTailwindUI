namespace BlazorTailwindUI.Services;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BlazorTailwindUI.Models;

/// <summary>
/// Native OpenTelemetry (OTel) Instrumentation and ActivitySource Service.
/// Collects high-precision component lifecycle spans, render latencies, and memory allocations.
/// </summary>
public class TwOpenTelemetryService
{
    private static readonly ActivitySource Tracer = new("BlazorTailwindUI.Tracing", "1.4.0");
    private readonly ConcurrentQueue<ComponentTraceSpan> _spans = new();
    private const int MaxSpans = 50;

    public event Action? OnTraceRecorded;

    public IReadOnlyList<ComponentTraceSpan> RecentSpans => _spans.Reverse().ToList();
    public int TotalRecordedCount { get; private set; }

    /// <summary>
    /// Records an execution span for a Blazor component lifecycle or service operation.
    /// </summary>
    public ComponentTraceSpan RecordSpan(string componentName, string operationName, double durationUs, Dictionary<string, string>? attributes = null)
    {
        using var activity = Tracer.StartActivity($"{componentName}.{operationName}");
        if (attributes != null && activity != null)
        {
            foreach (var kvp in attributes)
            {
                activity.SetTag(kvp.Key, kvp.Value);
            }
        }

        var span = new ComponentTraceSpan
        {
            TraceId = activity?.TraceId.ToString() ?? Guid.NewGuid().ToString("N"),
            SpanId = activity?.SpanId.ToString() ?? Guid.NewGuid().ToString("N")[..16],
            ParentSpanId = activity?.ParentSpanId.ToString(),
            ComponentName = componentName,
            OperationName = operationName,
            DurationMicroseconds = durationUs,
            Timestamp = DateTime.UtcNow,
            Attributes = attributes ?? new Dictionary<string, string>(),
            MemoryAllocatedBytes = GC.GetAllocatedBytesForCurrentThread()
        };

        _spans.Enqueue(span);
        while (_spans.Count > MaxSpans)
        {
            _spans.TryDequeue(out _);
        }

        TotalRecordedCount++;
        OnTraceRecorded?.Invoke();
        return span;
    }

    /// <summary>
    /// Simulates trace activity burst across fullstack rendering components.
    /// </summary>
    public void GenerateSimulatedBurst()
    {
        var components = new[] { "TwStreamingGrid", "TwHydratedView", "TwDonutCache", "TwPostQuantumVault", "TwUnionBoundary" };
        var operations = new[] { "BuildRenderTree", "OnParametersSetAsync", "HydrateFromCache", "ZstdDecompress", "ML_KEM_Encapsulate" };
        var rand = new Random();

        for (int i = 0; i < 5; i++)
        {
            var comp = components[i % components.Length];
            var op = operations[i % operations.Length];
            double us = rand.Next(80, 2400) + rand.NextDouble();
            RecordSpan(comp, op, us, new Dictionary<string, string>
            {
                ["render.mode"] = "InteractiveAuto",
                ["otel.status"] = "OK",
                ["net11.async_v2"] = "true"
            });
        }
    }
}
