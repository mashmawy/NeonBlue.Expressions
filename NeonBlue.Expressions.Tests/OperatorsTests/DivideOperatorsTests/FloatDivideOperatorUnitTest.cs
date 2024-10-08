using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.DivideOperatorsTests;

public class FloatDivideOperatorUnitTest
{
    [Fact]
    public void FloatDivideByteReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(10.0, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void FloatDivideIntegerFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(10.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatDivideLongFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(10.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatDivideDoubleFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20f, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(10.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void FloatDivideDecimalFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(10m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void FloatDivideFloatFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(10.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatDivideZeroFunctionReturnCorrectValueAndValueType()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(0, TokenType.Float);
        Assert.Throws<DivideByZeroException>(() =>
       {
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
       });
    }
    [Fact]
    public void FloatDivideNullFunctionDefaultOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void FloatDivideNullFunctionPropgateOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void FloatDivideNullFunctionThrowOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void FloatDivideOtherTypesFunctionThrowOption()
    {
        DivideOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}