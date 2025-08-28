namespace Calculator1;
public class Evaluator
{
    public static double EvaluatingRecursion(BinaryTree node)
    {
        return node.Value switch
        {
            INumbValue n => n.Evaluate(),
            IFunctionValue f => f.Evaluate(EvaluatingRecursion(node.Left)),
            IBinaryValue b => b.Evaluate(EvaluatingRecursion(node.Left), EvaluatingRecursion(node.Right)),
            _ => throw new InvalidOperationException()
        };
    }
}