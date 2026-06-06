namespace Prion.Node;
public sealed class PriNull: PriNode
{
    private PriNull(){}
    public override string ToString()
    {
        return "null";
    }
    public static readonly PriNull Null = new();
}