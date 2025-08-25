namespace Calculator1;
class Program
{
    static void Main(string[] args)
    {
        var root = new NTree(new AddOperator());
        var left = new NTree(new NumbValue(5));
        var right = new NTree(new DivOperator());
        var left1 = new NTree(new NumbValue(3));
        var right1 = new NTree(new AddOperator());
        var left2 = new NTree(new NumbValue(2));
        var right2 = new NTree(new NumbValue(2));
        
        root.AddLeft(left);
        root.AddRight(right);
        right.AddLeft(left1);
        right.AddRight(right1); 
        right1.AddLeft(left2);
        right1.AddRight(right2);
        
        Console.WriteLine(Evaluator.EvaluatingRecursion(root));
    }
}