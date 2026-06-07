using System.Text;
using Prion.Utils;

namespace Prion.Node;

public enum PriNodeKind
{
    Bool,
    Dict,
    Error,
    List,
    Null,
    Number,
    String,
    Variant,
}
public abstract class PriNode
{
    // public virtual bool IsError(){return false;}
    // public virtual bool IsImmutable(){return true;}
    protected static readonly StringBuilder Sb = new();
    protected static readonly PriSbPool SbPool = new();
    public abstract PriNodeKind Kind{get;}
    public virtual bool IsError{get => false;}
    public virtual bool IsImmutable{get => true;}
    // public virtual void PrettyPrint(int depth, ref StringBuilder sb)
    // {
    //     for (int i = 0; i < depth; i++)
    //     {
    //         sb.Append('\t');
    //         sb.Append(ToString());
    //     }
    // }
}