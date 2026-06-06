namespace Prion.Node;

public class PriString: PriNode
{
    public readonly string Value;
    public PriString(string value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"\"{Value}\"";
    }
}