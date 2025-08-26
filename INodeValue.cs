namespace Calculator1;

public interface INodeValue
{
    double Evaluate(double left, double right); 
    double Evaluate();
}

public class NumbValue : INodeValue
{
    private double _value;

    public NumbValue(double value)
    {
        _value = value;
    }

    public double Evaluate() => _value;
    public double Evaluate(double left, double right) 
        => throw new NotSupportedException("это не число");
}


public abstract class BinaryOperator : INodeValue
{
    public abstract double Operate(double left, double right);
    public double Evaluate(double left, double right) => Operate(left, right);
    public double Evaluate() 
        => throw new NotSupportedException("это не оператор");
}

public class AddOperator : BinaryOperator
{
    public override double Operate(double left, double right) => left + right;
}

public class SubOperator : BinaryOperator
{
    public override double Operate(double left, double right) => left - right;
}
public class MulOperator : BinaryOperator
{
    public override double Operate(double left, double right) => left * right;
}
public class DivOperator : BinaryOperator
{
    public override double Operate(double left, double right) => left / right;
}


