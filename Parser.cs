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

    private bool Eat(char c)
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
    
    public NTree ParseExpression() => ParseExpr();

    private NTree ParseExpr()
    {
        var node = ParseTerm();
        
        while (true)
        {
            if (Eat('+'))
            {
                var right = ParseTerm();
                var op = new AddOperator();
                var newNode = new NTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
            }
            else if (Eat('-'))
            {
                var right = ParseTerm();
                var op = new SubOperator();
                var newNode = new NTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
            }
            else break;
        }
        return node;
    }

    private NTree ParseTerm()
    {
        var node = ParseFactor();
        
        while (true)
        {
            if (Eat('*'))
            {
                var right = ParseFactor();
                var op = new MulOperator();
                var newNode = new NTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
            }
            else if (Eat('/'))
            {
                var right = ParseFactor();
                var op = new DivOperator();
                var newNode = new NTree(op);
                newNode.AddLeft(node);
                newNode.AddRight(right);
                node = newNode;
            }
            else break;
        }
        return node;
    }

    private NTree ParseFactor()
    {
        if (Eat('('))
        {
            var node = ParseExpr();
            if (!Eat(')')) throw new Exception("нужна закрывающая скобка");
            return node;
        }
        return ParseNumber();;
    }

    private NTree ParseNumber()
    {
        int start = _pos;

        while (char.IsDigit(Current) || Current == '.')
            Next();

        if (start == _pos) throw new Exception("кривое выражение");
        
        double value = double.Parse(_expression.Substring(start, _pos - start), System.Globalization.CultureInfo.InvariantCulture);
        var numb = new NTree(new NumbValue(value));
        
        return numb;
    }
}