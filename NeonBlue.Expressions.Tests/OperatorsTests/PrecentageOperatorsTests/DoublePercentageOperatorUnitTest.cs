using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PrecentageOperatorsTests;

public class DoublePercentageOperatorUnitTest
{
    [Fact]
    public void DoublePercentageByteReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoublePercentageIntegerFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePercentageLongFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePercentageFloatFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePercentageDecimalFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DoublePercentageDoubleFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoublePercentageNullFunctionDefaultOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DoublePercentageNullFunctionPropgateOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DoublePercentageNullFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DoublePercentageOtherTypesFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3.0, TokenType.Double);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}