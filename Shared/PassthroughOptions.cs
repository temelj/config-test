using System.ComponentModel.DataAnnotations;

namespace Shared;

/// <summary>
/// Passthrough options.
/// </summary>
public class PassthroughOptions : IPassthroughOptions
{
    /// <summary>
    /// Gets or sets the headers.
    /// </summary>
    public HashSet<string> Headers { get; } = new HashSet<string>();
}

public interface IPassthroughOptions
{
    /// <summary>
    /// Gets or sets the headers.
    /// </summary>
    public HashSet<string> Headers { get; }
}
