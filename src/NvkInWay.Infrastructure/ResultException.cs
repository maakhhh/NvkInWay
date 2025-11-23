namespace NvkInWay.Infrastructure;

public sealed class ResultException(ResultError error) : Exception(error.Message)
{
    public ResultError Error { get; } = error;
}