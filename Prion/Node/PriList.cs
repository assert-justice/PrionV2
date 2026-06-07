using Prion.Utils;

namespace Prion.Node;
public class PriList: PriNode
{
    public readonly List<PriNode> Values = [];
    public PriList(){}
    public PriList(List<PriNode> values)
    {
        Values = values;
    }
    public override bool IsImmutable(){return false;}
    public override string ToString()
    {
        var Sb = PriSbPool.Get();
        Sb.Append('[');
        foreach (var item in Values)
        {
            Sb.Append(item.ToString());
            Sb.Append(',');
        }
        Sb.Append(']');
        // if(Values.Count == 0) return "[]";
        // string str = $"[{Values[0]}";
        // for (int idx = 1; idx < Values.Count; idx++)
        // {
        //     str += $", {Values[idx]}";
        // }
        // str += "]";
        return PriSbPool.Free(Sb);
    }
}