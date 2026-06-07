namespace Prion.Node;

public class PriVariant<T>: PriNode where T : notnull
{
    public readonly T Value;
    public override PriNodeKind Kind => PriNodeKind.Variant;
    public PriVariant(T value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return Value.ToString() ?? $"{typeof(T)}";
    }
}