namespace Calculator1;

public interface INodeValue { }

public interface INumbValue : INodeValue
{
    double Evaluate();
}

public interface IFunctionValue : INodeValue
{
    double Evaluate(double operand);
}

public interface IBinaryValue : INodeValue
{
    double Evaluate(double left, double right);
}


public class NumbValue : INumbValue
{
    private readonly double _value;
    public NumbValue(double value) => _value = value;
    public double Evaluate() => _value;
}

public abstract class BinaryOperator : IBinaryValue
{
    public abstract double Evaluate(double left, double right);
}

public abstract class FunctionOperator : IFunctionValue
{
    public abstract double Evaluate(double operand);
}


public class SinFunction : FunctionOperator
{
    public override double Evaluate(double operand) => Math.Sin(operand);
}
public class CosFunction : FunctionOperator
{
    public override double Evaluate(double operand) => Math.Cos(operand);
}
public class TanFunction : FunctionOperator
{
    public override double Evaluate(double operand) => Math.Tan(operand);
}
public class CtgFunction : FunctionOperator
{
    public override double Evaluate(double operand) => 1/Math.Tan(operand);
}


public class AddOperator : BinaryOperator
{
    public override double Evaluate(double left, double right) => left + right;
}
public class SubOperator : BinaryOperator
{
    public override double Evaluate(double left, double right) => left - right;
}
public class MulOperator : BinaryOperator
{
    public override double Evaluate(double left, double right) => left * right;
}
public class DivOperator : BinaryOperator
{
    public override double Evaluate(double left, double right) => left / right;
}


