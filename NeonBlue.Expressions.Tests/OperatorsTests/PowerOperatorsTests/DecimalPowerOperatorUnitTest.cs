using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PowerOperatorsTests;

public class DecimalPowerOperatorUnitTest
{
    [Fact]
    public void DecimalPowerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token((decimal)2, TokenType.Decimal);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DecimalPowerByteFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DecimalPowerIntegerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DecimalPowerDoubleFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token((double)2, TokenType.Double);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DecimalPowerDecimalFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DecimalPowerLongFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token((long)2.0, TokenType.Long);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DecimalPowerNullFunctionDefaultOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DecimalPowerNullFunctionPropgateOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DecimalPowerNullFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DecimalPowerOtherTypesFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((decimal)2, TokenType.Decimal);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}