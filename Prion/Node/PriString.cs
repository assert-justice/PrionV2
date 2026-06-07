namespace Prion.Node;

public class PriString: PriNode
{
    public readonly string Value;
    public override PriNodeKind Kind => PriNodeKind.String;
    public PriString(string value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"\"{Value}\"";
    }
}