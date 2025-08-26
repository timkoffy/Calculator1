namespace Calculator1;
public class Evaluator
{
    public static double EvaluatingRecursion(BinaryTree node)
    {
        if (node.Left == null && node.Right == null)
            return node.Value.Evaluate();
        
        if (node.Right == null)
            return node.Value.Evaluate(EvaluatingRecursion(node.Left));
        
        
        double left = EvaluatingRecursion(node.Left);
        double right = EvaluatingRecursion(node.Right);

        return node.Value.Evaluate(left, right);
    }
}