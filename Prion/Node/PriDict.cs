namespace Prion.Node;
public class PriDict: PriNode
{
    public readonly Dictionary<string,PriNode> Data = [];
    public PriDict(){}
    public PriDict(Dictionary<string,PriNode> data)
    {
        Data = data;
    }
    public override bool IsImmutable(){return false;}
    public override string ToString()
    {
        if(Data.Count == 0) return "{}";
        var entries = Data.GetEnumerator();
        entries.MoveNext();
        var (key, value) = entries.Current;
        // string str = "{" + key + value.ToString();
        string str = $"{{{key}: {value}";
        while (entries.MoveNext())
        {
            (key, value) = entries.Current;
            str += $", {key}: {value}";
        }
        str += "}";
        return str;
    }
}