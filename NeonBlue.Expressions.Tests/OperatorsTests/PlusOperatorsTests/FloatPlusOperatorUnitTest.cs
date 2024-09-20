using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PlusOperatorsTests;

public class FloatPlusOperatorUnitTest
{
    [Fact]
    public void FloatPlusByteReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(22.0, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void FloatPlusIntegerFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(220f, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatPlusLongFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(220.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatPlusDoubleFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20f, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(220.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void FloatPlusDecimalFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(220m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void FloatPlusFloatFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(220f, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatPlusNullFunctionDefaultOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void FloatPlusNullFunctionPropgateOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void FloatPlusNullFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void FloatPlusStringReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Float);
        var operand2 = new Token("545", TokenType.String);
        var result =
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
        Assert.Equal("200545", Convert.ToString(result.Value));
    }

    [Fact]
    public void FloatPlusOtherTypesFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Float);
        var operand2 = new Token(DateTime.Now, TokenType.Datetime);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
}