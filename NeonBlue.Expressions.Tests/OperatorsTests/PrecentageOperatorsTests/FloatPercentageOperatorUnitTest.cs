using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PrecentageOperatorsTests;

public class FloatPercentageOperatorUnitTest
{
    [Fact]
    public void FloatPercentageByteReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(1.0, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void FloatPercentageIntegerFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(1.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatPercentageLongFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(1.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatPercentageDoubleFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(2f, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void FloatPercentageDecimalFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void FloatPercentageFloatFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(1.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatPercentageNullFunctionDefaultOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void FloatPercentageNullFunctionPropgateOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void FloatPercentageNullFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void FloatPercentageOtherTypesFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3f, TokenType.Float);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}