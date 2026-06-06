using System.Text;

namespace Prion.Node;

public class PriNumber: PriNode
{
    public enum NumberMode
    {
        SignedInt,
        UnsignedInt,
        Float,
    }
    public enum NumberRadix
    {
        Decimal,
        Hex,
        Binary,
    }
    private static readonly StringBuilder Sb = new();
    // public readonly string Literal;
    public readonly decimal Value;
    public readonly NumberMode Mode;
    public readonly int SizeInBits;
    public readonly NumberRadix Radix;
    // private int? I32_;
    // public int I32{get => I32_ ??= int.Parse(Literal, GetIntNumberStyle());}
    // private long? I64_;
    // public long I64{get => I64_ ??= long.Parse(Literal, GetIntNumberStyle());}
    // private ulong? U64_;
    // public ulong U64{get => U64_ ??= ulong.Parse(Literal, GetIntNumberStyle());}
    public PriNumber(decimal value, NumberMode mode, int sizeInBits, NumberRadix radix = NumberRadix.Decimal)
    {
        Value = value;
        Mode = mode;
        SizeInBits = sizeInBits;
        Radix = radix;
    }
    public PriNumber(double value, NumberRadix radix = NumberRadix.Decimal):this((decimal)value, NumberMode.Float, 64, radix){}
    public PriNumber(float value, NumberRadix radix = NumberRadix.Decimal):this((decimal)value, NumberMode.Float, 32, radix){}
    public PriNumber(sbyte value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.UnsignedInt, 8, radix){}
    public PriNumber(short value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.SignedInt, 16, radix){}
    public PriNumber(int value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.SignedInt, 32, radix){}
    public PriNumber(long value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.SignedInt, 64, radix){}
    public PriNumber(byte value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.UnsignedInt, 8, radix){}
    public PriNumber(ushort value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.UnsignedInt, 16, radix){}
    public PriNumber(uint value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.UnsignedInt, 32, radix){}
    public PriNumber(ulong value, NumberRadix radix = NumberRadix.Decimal):this(value, NumberMode.UnsignedInt, 64, radix){}
    // private System.Globalization.NumberStyles GetIntNumberStyle()
    // {
    //     // System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Integer;
    //     return Radix switch
    //     {
    //         NumberRadix.Decimal => System.Globalization.NumberStyles.Integer,
    //         NumberRadix.Hex => System.Globalization.NumberStyles.HexNumber & System.Globalization.NumberStyles.AllowLeadingSign,
    //         NumberRadix.Binary => System.Globalization.NumberStyles.BinaryNumber & System.Globalization.NumberStyles.AllowLeadingSign,
    //         _ => System.Globalization.NumberStyles.None,
    //     };
    // }
    public override string ToString()
    {
        Sb.Clear();
        decimal value = Value;
        if(value < 0)
        {
            Sb.Append('-');
            value = -value;
        }
        if(Radix == NumberRadix.Hex) Sb.Append("0x");
        else if(Radix == NumberRadix.Binary) Sb.Append("0b");
        switch (Radix)
        {
            case NumberRadix.Hex:
                // Sb.Append(Value.ToString("X"));
                if(Mode == NumberMode.SignedInt) Sb.Append(string.Format("{0:x}", (long)value));
                else Sb.Append(string.Format("{0:x}", (ulong)Value));
                break;
            case NumberRadix.Binary:
                // Sb.Append(Value.ToString("B"));
                if(Mode == NumberMode.SignedInt) Sb.Append(string.Format("{0:b}", (long)value));
                else Sb.Append(string.Format("{0:b}", (ulong)Value));
                break;
            default:
                Sb.Append(Value);
                if(Mode == NumberMode.Float && !Value.ToString().Contains('.')) Sb.Append(".0");
                break;
        }
        if(Mode == NumberMode.Float)
        {
            if(SizeInBits != 64)  Sb.Append($"f{SizeInBits}");
            return Sb.ToString();
        }
        if(Mode == NumberMode.SignedInt && SizeInBits == 32) return Sb.ToString();
        Sb.Append(Mode == NumberMode.SignedInt ? $"i{SizeInBits}" : $"u{SizeInBits}");
        return Sb.ToString();
    }
}