namespace Calculator1;

public class Parser
{
    private readonly string _expression;
    private int _pos;

    public Parser(string expression)
    {
        _expression = expression.Replace(" ", "");
        _pos = 0;
    }

    private bool IsThisCharCurrent(char c)
    {
        if (c == Current)
        {
            Next();
            return true;
        }
        return false;
    }
    
    private char Current => _pos < _expression.Length ? _expression[_pos] : '\0';
    private void Next() => _pos++;

    private BinaryTree CreateNode(INodeValue op, BinaryTree left, BinaryTree? right)
    {
        var newNode = new BinaryTree(op);
        newNode.AddLeft(left);
        if (right != null) newNode.AddRight(right);
        return newNode;
    }

    private string FunctionIdentifier()
    {
        int start = _pos;
        while (char.IsLetter(Current)) Next();
        return _expression.Substring(start, _pos - start);
    }
    
    public BinaryTree ParseExpression()
    {
        var node = ParseTerm();
        
        while (true)
        {
            if (IsThisCharCurrent('+'))
            {
                var right = ParseTerm();
                node = CreateNode(new AddOperator(), node, right);
            }
            else if (IsThisCharCurrent('-'))
            {
                var right = ParseTerm();
                node = CreateNode(new SubOperator(), node, right);
            }
            else break;
        }
        return node;
    }

    private BinaryTree ParseTerm()
    {
        var node = ParseFactor();
        
        while (true)
        {
            if (IsThisCharCurrent('*'))
            {
                var right = ParseFactor();
                node = CreateNode(new MulOperator(), node, right);
            }
            else if (IsThisCharCurrent('/'))
            {
                var right = ParseFactor();
                node = CreateNode(new DivOperator(), node, right);
            }
            else break;
        }
        return node;
    }

    private BinaryTree ParseFactor()
    {
        if (IsThisCharCurrent('('))
        {
            var node = ParseExpression();
            if (!IsThisCharCurrent(')')) throw new Exception("missing closing parenthesis");
            return node;
        }

        if (char.IsLetter(Current))
        {
            string func = FunctionIdentifier();
            while (!IsThisCharCurrent('(')) Next(); 
            var node = ParseExpression(); 
            if (!IsThisCharCurrent(')')) throw new Exception("missing closing parenthesis");

            return func switch
            {
                "sin" => CreateNode(new SinFunction(), node, null),
                "cos" => CreateNode(new CosFunction(), node, null),
                "tan" => CreateNode(new TanFunction(), node, null),
                "ctg" => CreateNode(new CtgFunction(), node, null),
            };
        }
        
        return ParseNumber();;
    }

    private BinaryTree ParseNumber()
    {
        int start = _pos;
        IsThisCharCurrent('-');

        while (char.IsDigit(Current) || Current == '.')
            Next();

        if (start == _pos) throw new Exception("invalid expression");
        
        double value = double.Parse(_expression.Substring(start, _pos - start), System.Globalization.CultureInfo.InvariantCulture);
        
        var numb = new BinaryTree(new NumbValue(value));
        
        return numb;
    }
}