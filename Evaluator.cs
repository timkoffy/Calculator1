namespace Calculator1;
public class Evaluator
{
    public static double Evaluate(NTree node)
    {
        if (node.Left == null && node.Right == null)
            return node.Value.Evaluate();
        
        double left = Evaluate(node.Left);
        double right = Evaluate(node.Right);

        return node.Value.Evaluate(left, right);
    }
}