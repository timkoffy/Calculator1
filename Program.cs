namespace Calculator1;
class Program
{
    static void Main(string[] args)
    {
        string expression = Console.ReadLine();
        var parser = new Parser(expression);
        var root = parser.ParseExpression();
        Console.WriteLine(Evaluator.EvaluatingRecursion(root));
    }
}