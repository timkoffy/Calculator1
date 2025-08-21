namespace Calculator1;
class Program
{
    static void Main(string[] args)
    {
        var root = new NTree("+");
        var left = new NTree("5");
        var right = new NTree("/");
        var left1 = new NTree("3");
        var right1 = new NTree("+");
        var left2 = new NTree("2");
        var right2 = new NTree("2");
        
        root.AddLeft(left);
        root.AddRight(right);
        right.AddLeft(left1);
        right.AddRight(right1); 
        right1.AddLeft(left2);
        right1.AddRight(right2);
        
        Console.WriteLine(Evaluator.Evaluate(root));
    }
}