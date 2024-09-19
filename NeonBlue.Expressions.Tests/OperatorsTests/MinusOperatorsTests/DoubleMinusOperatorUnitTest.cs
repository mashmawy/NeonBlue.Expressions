using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MinusOperatorsTests;

public class DoubleMinusOperatorUnitTest
{
    [Fact]
    public void DoubleMinusByteReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20.0, TokenType.Double);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(18.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoubleMinusIntegerFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(180.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoubleMinusLongFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(180.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoubleMinusFloatFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(180.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoubleMinusDecimalFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DoubleMinusDoubleFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(180.0, Convert.ToDouble(result.Value));
    } 
    [Fact]
    public void DoubleMinusNullFunctionDefaultOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DoubleMinusNullFunctionPropgateOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DoubleMinusNullFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DoubleMinusOtherTypesFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}