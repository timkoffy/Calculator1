namespace Calculator1;

public interface INodeValue
{
    double Evaluate(double left, double right); 
    double Evaluate(double left);
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
        => throw new NotSupportedException("not a number");
    public double Evaluate(double left) 
        => throw new NotSupportedException("not a number");
}


public abstract class BinaryOperator : INodeValue
{
    public abstract double Operate(double left, double right);
    public double Evaluate(double left, double right) => Operate(left, right);
    public double Evaluate() 
        => throw new NotSupportedException("not an operator");
    public double Evaluate(double left) 
        => throw new NotSupportedException("not an operator");
}

public abstract class FunctionOperator : INodeValue
{
    public abstract double Operate(double left);
    public double Evaluate(double left) => Operate(left);
    public double Evaluate(double left, double right)
        => throw new NotSupportedException("not a function");
    public double Evaluate() 
        => throw new NotSupportedException("not a function");
    
}

public class SinFunction : FunctionOperator
{
    public override double Operate(double left) => Math.Sin(left);
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


