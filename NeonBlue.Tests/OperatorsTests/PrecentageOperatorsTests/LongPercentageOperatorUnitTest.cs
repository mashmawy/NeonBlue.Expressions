using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PrecentageOperatorsTests;

public class LongPercentageOperatorUnitTest
{
    [Fact]
    public void LongPercentageFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token((byte)2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(1, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void LongPercentageIntegerFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(1, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongPercentageLongFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(1, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void LongPercentageFloatFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(1, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongPercentageDecimalFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void LongPercentageDoubleFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void LongPercentageNullFunctionDefaultOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void LongPercentageNullFunctionPropgateOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void LongPercentageNullFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void LongPercentageOtherTypesFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Long);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}