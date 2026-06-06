namespace Prion.Node;
public abstract class PriNode
{
    public virtual bool IsError(){return false;}
    public virtual bool IsImmutable(){return true;}
    // public virtual void PrettyPrint(int depth, ref StringBuilder sb)
    // {
    //     for (int i = 0; i < depth; i++)
    //     {
    //         sb.Append('\t');
    //         sb.Append(ToString());
    //     }
    // }
}