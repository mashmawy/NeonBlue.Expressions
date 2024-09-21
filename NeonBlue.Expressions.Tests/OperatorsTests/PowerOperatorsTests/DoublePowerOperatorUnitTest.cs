using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PowerOperatorsTests;

public class DoublePowerOperatorUnitTest
{
    [Fact]
    public void DoublePowerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token((double)2, TokenType.Double);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoublePowerByteFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePowerIntegerFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePowerFloatFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePowerDecimalFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePowerDoubleFunctionReturnCorrectValueAndValueType()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token((long)2.0, TokenType.Long);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoublePowerNullFunctionDefaultOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DoublePowerNullFunctionPropgateOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DoublePowerNullFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DoublePowerOtherTypesFunctionThrowOption()
    {
        PowerOperatorOverloads powerOperatorOverloads = new();
        var operand1 = new Token((double)2, TokenType.Double);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            powerOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}