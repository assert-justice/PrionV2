namespace Prion.Node;

public class PriBool: PriNode
{
    public readonly bool Value;
    private PriBool(bool value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return Value ? "true" : "false";
    }
    public static readonly PriBool True = new(true);
    public static readonly PriBool False = new(false);
}