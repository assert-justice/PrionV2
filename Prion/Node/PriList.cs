using System.Reflection.Metadata;
using Prion.Node.Converter;

namespace Prion.Node;
public class PriList: PriNode
{
    public readonly List<PriNode> Values;
    public PriList()
    {
        Values = [];
    }
    public PriList(List<PriNode> values)
    {
        Values = values;
    }
    public PriList(int capacity)
    {
        Values = new(capacity);
    }
    public override PriNodeKind Kind => PriNodeKind.List;
    public override bool IsImmutable => false;
    public bool TryGet<T>(int idx, out T value)
    {
        value = default!;
        if(idx < 0 || idx >= Values.Count) return false;
        var priNode = Values[idx];
        if(priNode is T val)
        {
            value = val;
            return true;
        }
        return PriNodeConverter.TryToValue(priNode, out value);
    }
    public bool TrySet<T>(int idx, T value)
    {
        if(idx < 0 || idx >= Values.Count) return false;
        if(value is PriNode priNode){}
        else if(PriNodeConverter.TryToPrion(value, out priNode)){}
        else return false;
        Values[idx] = priNode;
        return true;
    }
    public bool TryAdd<T>(T value)
    {
        if(value is PriNode priNode){}
        // {
        //     Values.Add(priNode);
        //     return true;
        // }
        else if(PriNodeConverter.TryToPrion(value, out priNode)){}
        else return false;
        Values.Add(priNode);
        return true;
    }
    private IEnumerable<T> GetValues<T>()
    {
        foreach (var item in Values)
        {
            if(item is T val) yield return val;
            else if(PriNodeConverter.TryToValue(item, out val)) yield return val;
            else yield break;
        }
    }
    public bool TryAs<T>(out List<T> values)
    {
        values = [..GetValues<T>()];
        if(values.Count == Values.Count) return true;
        values.Clear();
        return false;
    }
    public bool TryAs<T>(out T[] values)
    {
        values = [..GetValues<T>()];
        if(values.Length == Values.Count) return true;
        values = [];
        return false;
    }
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
    public static bool TryFrom<T>(IEnumerable<T> values, out PriList priList)
    {
        if(values.TryGetNonEnumeratedCount(out int count)) priList = new(count);
        else priList = new();
        if(!PriNodeConverter.TryGetConverter(typeof(T), out var converter)) return false;
        foreach (var item in values)
        {
            converter.TryToPrion(item, out var priNode);
            priList.Values.Add(priNode);
        }
        return true;
    }
}