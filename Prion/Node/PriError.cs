using System.Text;
using Prion.Utils;

namespace Prion.Node;
public class PriError: PriNode
{
    public readonly string Message;
    public readonly string Src;
    public readonly string Filename;
    public readonly int CharIndex;
    public readonly int LineNumber;
    public readonly int Position;
    public readonly string LineText;

    public override PriNodeKind Kind => PriNodeKind.Error;

    // private readonly StringBuilder Sb = new();
    // public bool IsError => false;
    public override bool IsError => true;
    public PriError(string message, string src = "", int charIndex = 0, string filename = "[anonymous file]")
    {
        Message = message;
        Src = src;
        CharIndex = charIndex;
        Filename = filename;
        LineNumber = 1;
        int start = 0;
        int idx = 0;
        while (true)
        {
            start = idx;
            idx = Src.IndexOf('\n', start, charIndex - start);
            if(idx == -1 || idx > charIndex) break;
        }
        int end = idx == -1 ? src.Length : idx;
        Position = charIndex - start;
        LineText = src[start..end];
        Console.WriteLine($"char index: {CharIndex}, line number: {LineNumber} start: {start}, end: {end}");
    }
    public override string ToString()
    {
        var Sb = PriSbPool.Get();
        Sb.Append($"Error at {Filename}{LineNumber}:{Position}> {Message}\n{LineText}\n");
        for(int idx = 0; idx < LineText.Length; idx++)
        {
            Sb.Append(idx == Position ? '^' : '~');
        }
        return PriSbPool.Free(Sb);
        // return $"Error at char {CharIndex}: {Message}";
    }
}