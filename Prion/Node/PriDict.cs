// using System.Text;

using Prion.Utils;

namespace Prion.Node;
public class PriDict: PriNode
{
    public readonly Dictionary<string,PriNode> Data = [];
    // private static readonly StringBuilder Sb = new();
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
        var Sb = PriSbPool.Get();
        Sb.Append('{');
        foreach (var (key, value) in Data)
        {
            Sb.Append(key);
            Sb.Append(": ");
            Sb.Append(value.ToString());
            Sb.Append(',');
        }
        Sb.Append('}');
        return PriSbPool.Free(Sb);
        // var entries = Data.GetEnumerator();
        // entries.MoveNext();
        // var (key, value) = entries.Current;
        // // string str = "{" + key + value.ToString();
        // string str = $"{{{key}: {value}";
        // while (entries.MoveNext())
        // {
        //     (key, value) = entries.Current;
        //     str += $", {key}: {value}";
        // }
        // str += "}";
        // return str;
    }
}