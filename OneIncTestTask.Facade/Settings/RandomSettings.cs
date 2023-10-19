using Foolproof;

namespace OneIncTestTask.Facade.Configurations;

public record RandomSettings
{
    public int MinValue { get; init; }

    public int MaxValue { get; init; }
};
