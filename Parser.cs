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
        
    }
}