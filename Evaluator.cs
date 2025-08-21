namespace Calculator1;
public class Evaluator
{
    public static double Evaluate(NTree node)
    {
        if (node.Left == null && node.Right == null)
            return double.Parse(node.Value);
        
        double left = Evaluate(node.Left);
        double right = Evaluate(node.Right);

        return node.Value switch
        {
            "+" => left + right,
            "-" => left - right,
            "*" => left * right,
            "/" => left / right
        };
    }
}