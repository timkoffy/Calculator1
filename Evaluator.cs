namespace Calculator1;
public class Evaluator
{
    public static double EvaluatingRecursion(NTree node)
    {
        if (node.Left == null && node.Right == null)
            return node.Value.Evaluate();
        
        double left = EvaluatingRecursion(node.Left);
        double right = EvaluatingRecursion(node.Right);

        return node.Value.Evaluate(left, right);
    }
}