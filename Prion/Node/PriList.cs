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
        if(Values.Count == 0) return "[]";
        string str = $"[{Values[0]}";
        for (int idx = 1; idx < Values.Count; idx++)
        {
            str += $", {Values[idx]}";
        }
        str += "]";
        return str;
    }
}