namespace Calculator1;
public class Evaluator
{
    public static string Evaluate(string tree)
    {
        string result;
        while (tree.Contains('('))
        {
            for (int i = 0; i < tree.Length; i++)
            {
                if (tree[i]==')')
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (tree[j] == '(')
                        {
                            string primitiveExp = tree.Substring(j + 1, i - j - 1);
                            double value = PrimitiveCalc(primitiveExp);
                            tree = tree.Substring(0, j) + value + tree.Substring(i + 1);
                            break;
                        }
                    }
                    break;
                }
            }
        }
        
        result = tree;
        return result;
    }

    private static double PrimitiveCalc(string expression)
    {
        string[] exp =  expression.Split(' ');
        char op = Convert.ToChar(exp[0]);
        double first = Convert.ToDouble(exp[1]);
        double second = Convert.ToDouble(exp[2]);
        
        return op switch
        {
            '+' => first + second,
            '-' => first - second,
            '*' => first * second,
            '/' => first / second
        };
    }
}