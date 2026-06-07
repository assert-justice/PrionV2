using System.Text;

namespace Prion.Utils;

internal static class PriSbPool
{
    private static readonly Queue<StringBuilder> SbQueue = [];
    public static StringBuilder Get()
    {
        if(!SbQueue.TryDequeue(out var sb)) return new();
        sb.Clear();
        return sb;
    }
    public static string Free(StringBuilder stringBuilder)
    {
        SbQueue.Enqueue(stringBuilder);
        return stringBuilder.ToString();
    }
}