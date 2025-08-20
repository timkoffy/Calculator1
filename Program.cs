namespace Calculator1;
class Program
{
    static void Main()
    {
        string inputText = "(+ 5 (/ 3 (+ 2 2)))";
        string result = Evaluator.Evaluate(inputText);
        Console.WriteLine(result);
    }
}