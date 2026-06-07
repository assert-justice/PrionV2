using System.Text;

namespace Prion.Utils;

internal static class PriSb
{
    private static StringBuilder? _Sb;
    public static StringBuilder Sb
    {
        get => _Sb ??= new();
    }
}