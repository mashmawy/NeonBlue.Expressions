using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PrecentageOperatorsTests;

public class DecimalPercentageOperatorUnitTest
{
    [Fact]
    public void DecimalPercentageByteReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }

    [Fact]
    public void DecimalPercentageIntegerFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalPercentageLongFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalPercentageFloatFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalPercentageDecimalFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalPercentageDoubleFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }

    [Fact]
    public void DecimalPercentageNullFunctionDefaultOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DecimalPercentageNullFunctionPropgateOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DecimalPercentageNullFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    

}