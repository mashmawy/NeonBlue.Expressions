using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PowerOperatorsTests;

public class IntegerPowerOperatorUnitTest
{
    [Fact]
    public void IntegerPowerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void IntegerPowerByteFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void IntegerPowerLongFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void IntegerPowerFloatFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void IntegerPowerDecimalFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void IntegerPowerDoubleFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void IntegerPowerNullFunctionDefaultOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void IntegerPowerNullFunctionPropgateOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void IntegerPowerNullFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void IntegerPowerOtherTypesFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}
