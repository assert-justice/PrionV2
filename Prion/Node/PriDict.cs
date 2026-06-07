using Prion.Node.Converter;

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
    public bool TryGet<T>(string key, out T value)
    {
        value = default!;
        if(!Data.TryGetValue(key, out var priNode)) return false;
        if(priNode is T val)
        {
            value = val;
            return true;
        }
        return PriNodeConverter.TryToValue(priNode, out value);
    }
    public bool TryGetList<T>(string key, out List<T> values)
    {
        values = default!;
        if(!TryGet(key, out PriList priList)) return false;
        return priList.TryAs(out values);
    }
    public bool TryGetList<T>(string key, out T[] values)
    {
        values = default!;
        if(!TryGet(key, out PriList priList)) return false;
        return priList.TryAs(out values);
    }
    public bool TrySet<T>(string key, T value)
    {
        if(value is PriNode priNode){}
        else if(PriNodeConverter.TryToPrion(value, out priNode)){}
        else{}
        Data[key] = priNode;
        return true;
    }
    public bool TrySetList<T>(string key, IEnumerable<T> values)
    {
        if(!PriList.TryFrom(values, out var priList)) return false;
        Data[key] = priList;
        return true;
    }
    public override string ToString()
    {
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