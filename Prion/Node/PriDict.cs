namespace Prion.Node;
public class PriDict: PriNode
{
    public readonly Dictionary<string,PriNode> Data = [];
    public PriDict(){}
    public PriDict(Dictionary<string,PriNode> data)
    {
        Data = data;
    }

    public override PriNodeKind Kind => PriNodeKind.Dict;
    public override bool IsImmutable => false;
    public override string ToString()
    {
        // if(Data.Count == 0) return "{}";
        var sb = SbPool.Get();
        sb.Append('{');
        foreach (var (key, value) in Data)
        {
            sb.Append(key);
            sb.Append(": ");
            sb.Append(value.ToString());
            sb.Append(',');
        }
        sb.Append('}');
        return SbPool.Free(sb);
    }
}