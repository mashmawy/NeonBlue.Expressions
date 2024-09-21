using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PowerOperatorsTests;

public class LongPowerOperatorUnitTest
{
    [Fact]
    public void LongPowerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(2, TokenType.Long);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void LongPowerByteFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void LongPowerIntegerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void LongPowerFloatFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void LongPowerDecimalFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void LongPowerDoubleFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void LongPowerNullFunctionDefaultOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void LongPowerNullFunctionPropgateOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void LongPowerNullFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void LongPowerOtherTypesFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}
