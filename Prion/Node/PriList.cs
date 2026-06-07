namespace Prion.Node;
public class PriList: PriNode
{
    public readonly List<PriNode> Values = [];
    public PriList(){}
    public PriList(List<PriNode> values)
    {
        Values = values;
    }
    public override PriNodeKind Kind => PriNodeKind.List;
    public override bool IsImmutable => false;
    public override string ToString()
    {
        var sb = SbPool.Get();
        sb.Append('[');
        foreach (var item in Values)
        {
            sb.Append(item.ToString());
            sb.Append(',');
        }
        sb.Append(']');
        return SbPool.Free(sb);
    }
}