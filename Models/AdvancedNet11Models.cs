namespace BlazorTailwindUI.Models;

using System;
using System.Collections.Generic;

/// <summary>
/// Modern C# 15 Discriminated Union pattern for type-safe asynchronous UI state machines.
/// Enables compiler-checked exhaustiveness and eliminates untyped null states.
/// </summary>
public abstract record UiState<T>
{
    public sealed record Loading : UiState<T>;
    public sealed record Success(T Data) : UiState<T>;
    public sealed record Empty : UiState<T>;
    public sealed record Failure(string Message, Exception? Exception = null) : UiState<T>;

    public bool IsLoading => this is Loading;
    public bool IsSuccess => this is Success;
    public bool IsEmpty => this is Empty;
    public bool IsFailure => this is Failure;

    public T? DataOrNull => this is Success s ? s.Data : default;
}

/// <summary>
/// Functional Result union type for robust operation handling.
/// </summary>
public abstract record Result<T, E>
{
    public sealed record Ok(T Value) : Result<T, E>;
    public sealed record Err(E Error) : Result<T, E>;

    public bool IsOk => this is Ok;
    public bool IsErr => this is Err;
}

/// <summary>
/// Donut Caching model representing a cached SSR/prerendered segment with dynamic hole perforations.
/// </summary>
public class DonutCacheEntry
{
    public string Key { get; set; } = string.Empty;
    public string StaticHtml { get; set; } = string.Empty;
    public DateTime CachedAt { get; set; } = DateTime.UtcNow;
    public TimeSpan Ttl { get; set; } = TimeSpan.FromMinutes(5);
    public List<string> Tags { get; set; } = new();
    public int HitCount { get; set; }
    public int DynamicHoleCount { get; set; }
    public double GenerationDurationMs { get; set; }

    public bool IsExpired => DateTime.UtcNow - CachedAt > Ttl;
}

/// <summary>
/// Donut Cache runtime telemetry metrics.
/// </summary>
public class DonutCacheTelemetry
{
    public int TotalHits { get; set; }
    public int TotalMisses { get; set; }
    public int ActiveEntries { get; set; }
    public int EvictionCount { get; set; }
    public double EstimatedLatencySavedMs { get; set; }
    public double HitRatio => (TotalHits + TotalMisses) == 0 ? 0 : (double)TotalHits / (TotalHits + TotalMisses);
}

/// <summary>
/// Zstandard compression benchmark result.
/// </summary>
public class ZstandardBenchmarkResult
{
    public string PayloadName { get; set; } = string.Empty;
    public long OriginalSizeBytes { get; set; }
    public long CompressedSizeBytes { get; set; }
    public double CompressionRatio => OriginalSizeBytes == 0 ? 0 : (double)CompressedSizeBytes / OriginalSizeBytes;
    public double SavingsPercentage => OriginalSizeBytes == 0 ? 0 : (1.0 - CompressionRatio) * 100.0;
    public double CompressionDurationMs { get; set; }
    public double DecompressionDurationMs { get; set; }
    public double SpeedMBps { get; set; }
    public string CompressionFormat { get; set; } = "Zstandard (v1.5.6 Native)";
}

/// <summary>
/// Post-Quantum Cryptography (PQC) Enclave evaluation model (ML-KEM / HPKE).
/// </summary>
public class PostQuantumEnclaveResult
{
    public string Algorithm { get; set; } = "ML-KEM-768 (NIST FIPS 203)";
    public string KeyId { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string EncapsulatedCiphertextHex { get; set; } = string.Empty;
    public string DecapsulatedSecretHex { get; set; } = string.Empty;
    public string PlaintextPayload { get; set; } = string.Empty;
    public string EncryptedEnvelopeBase64 { get; set; } = string.Empty;
    public string DecryptedPayload { get; set; } = string.Empty;
    public double HandshakeDurationMs { get; set; }
    public bool IsDecryptionVerified { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// OpenTelemetry component trace span tracking lifecycle durations and memory pressure.
/// </summary>
public class ComponentTraceSpan
{
    public string TraceId { get; set; } = Guid.NewGuid().ToString("N");
    public string SpanId { get; set; } = Guid.NewGuid().ToString("N")[..16];
    public string? ParentSpanId { get; set; }
    public string ComponentName { get; set; } = string.Empty;
    public string OperationName { get; set; } = "BuildRenderTree";
    public double DurationMicroseconds { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public Dictionary<string, string> Attributes { get; set; } = new();
    public long MemoryAllocatedBytes { get; set; }
}
