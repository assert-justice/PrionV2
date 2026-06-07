using Prion.Node;
using Prion.Utils;

namespace Prion.Parser;

public class PriPrettyPrinter
{
    // private static readonly StringBuilder Sb = new();
    public string PrettyPrint(PriNode priNode)
    {
        PriSb.Sb.Clear();
        PrintNode(priNode, 0);
        return PriSb.Sb.ToString();
    }
    private static void Indent(int depth)
    {
        for (int idx = 0; idx < depth; idx++)
        {
            PriSb.Sb.Append('\t');
        }
    }
    private void PrintNode(PriNode priNode, int depth)
    {
        if(priNode is PriDict priDict) PrintDict(priDict, depth);
        else if(priNode is PriList priList) PrintList(priList, depth);
        else PriSb.Sb.Append(priNode.ToString());
    }
    private void PrintDict(PriDict priDict, int depth)
    {
        PriSb.Sb.Append("{\n");
        foreach (var (key,value) in priDict.Data)
        {
            Indent(depth + 1);
            PriSb.Sb.Append(key);
            PriSb.Sb.Append(": ");
            PrintNode(value, depth + 1);
            PriSb.Sb.Append(",\n");
        }
        Indent(depth);
        PriSb.Sb.Append('}');
    }
    private void PrintList(PriList priList, int depth)
    {
        PriSb.Sb.Append("[\n");
        foreach (var item in priList.Values)
        {
            Indent(depth + 1);
            PrintNode(item, depth + 1);
            PriSb.Sb.Append(",\n");
        }
        Indent(depth);
        PriSb.Sb.Append(']');
    }
}