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
    // private static readonly Dictionary<Type,()>
    protected static readonly StringBuilder Sb = new();
    protected static readonly PriSbPool SbPool = new();
    public abstract PriNodeKind Kind{get;}
    public virtual bool IsError{get => false;}
    public virtual bool IsImmutable{get => true;}
}