namespace Calculator1;

public class Parser
{
    private readonly string _expression;
    private int _pos;

    Parser(string expression)
    {
        _expression = expression.Replace(" ", "");
        _pos = 0;
    }

    private bool Eat(char c)
    {
        if (c == _pos)
        {
            return true;
        }
        return false;
    }
    
    private char Current => _pos < _expression.Length ? _expression[_pos] : '\0';
    private void Next() => _pos++;
    
    private NTree ParseExpression() => ParseExpr();

    private NTree ParseExpr()
    {
        
    }

    private NTree ParseTerm()
    {
        
    }

    private NTree ParseFactor()
    {
        
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