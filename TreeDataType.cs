namespace Calculator1;

public class BinaryTree
{
    public INodeValue Value { get; }
    public BinaryTree Left { get; private set; }
    public BinaryTree Right { get; private set; }

    public BinaryTree(INodeValue value) => Value = value;
    
    public void AddLeft(BinaryTree child) => Left = child;

    public void AddRight(BinaryTree child) => Right = child;
}