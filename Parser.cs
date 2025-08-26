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

    public BinaryTree ParseExpression()
    {
        var node = ParseTerm();
        
        while (true)
        {
            if (IsThisCharCurrent('+'))
            {
                var right = ParseTerm();
                var op = new AddOperator();
                var newNode = new BinaryTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
            }
            else if (IsThisCharCurrent('-'))
            {
                var right = ParseTerm();
                var op = new SubOperator();
                var newNode = new BinaryTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
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
                var op = new MulOperator();
                var newNode = new BinaryTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
            }
            else if (IsThisCharCurrent('/'))
            {
                var right = ParseFactor();
                var op = new DivOperator();
                var newNode = new BinaryTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
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
            if (!IsThisCharCurrent(')')) throw new Exception("нужна закрывающая скобка");
            return node;
        } 
        if (IsThisCharCurrent('s'))
        {
            while (!IsThisCharCurrent('('))
            {
                Next();
            }
            var node = ParseFactor(); 
            var fc = new SinFunction();
            var newNode = new BinaryTree(fc);
            newNode.AddLeft(node);
            node = newNode;
            return node;
        }
        return ParseNumber();;
    }

    private BinaryTree ParseNumber()
    {
        int start = _pos;

        while (char.IsDigit(Current) || Current == '.')
            Next();

        if (start == _pos) throw new Exception("кривое выражение");
        
        double value = double.Parse(_expression.Substring(start, _pos - start), System.Globalization.CultureInfo.InvariantCulture);
        var numb = new BinaryTree(new NumbValue(value));
        
        return numb;
    }
}