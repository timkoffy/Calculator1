namespace Calculator1;

public class NTree
{
    public string Value { get; set; }
    public NTree? Left { get; private set; }
    public NTree? Right { get; private set; }

    public NTree(string value)
    {
        Value = value;
    }
    
    public void AddLeft(NTree child)
    {
        Left = child;
    }

    public void AddRight(NTree child)
    {
        Right = child;
    }
}