using System.Diagnostics;

namespace NvkInWay.Infrastructure;

[DebuggerDisplay("[{Id}] {Message}")]
public class ResultError
{
    public ResultError(string? id, string? message)
    {
        Id = id ?? "about:blank";
        Message = message ?? "An unknown error has occured.";
        Extensions = new Dictionary<string, object?>(StringComparer.Ordinal);
    }

    public string Id { get; }

    public string Message { get; }

    public IDictionary<string, object?> Extensions { get; }

    public void Deconstruct(out string id, out string? message)
    {
        id = Id;
        message = Message;
    }

    public void Deconstruct(out string id, out string? message, out IDictionary<string, object?> extensions)
    {
        id = Id;
        message = Message;
        extensions = Extensions;
    }

    public override string ToString()
    {
        if (Extensions.Count == 0) return $"Id: '{Id}', Message: '{Message}'";

        return $"Id: '{Id}', Message: '{Message}', Extensions: " +
               $"{{{string.Join(", ", Extensions!.Select((Func<KeyValuePair<string, object>, string>)(kv => $"{kv.Key}={kv.Value}")))}}}";
    }
}