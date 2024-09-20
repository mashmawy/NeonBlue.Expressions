using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PlusOperatorsTests;

public class DoublePlusOperatorUnitTest
{
    [Fact]
    public void DoublePlusByteReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20.0, TokenType.Double);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(22.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoublePlusIntegerFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(220.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePlusLongFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(220.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePlusFloatFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(220.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePlusDecimalFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(220m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DoublePlusDoubleFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(220.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoublePlusNullFunctionDefaultOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DoublePlusNullFunctionPropgateOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DoublePlusNullFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DoublePlusStringReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Double);
        var operand2 = new Token("545", TokenType.String);
        var result =
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value.GetType() == typeof(string));
        Assert.Equal("200545", Convert.ToString(result.Value));
    }

    [Fact]
    public void DoublePlusOtherTypesFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Double);
        var operand2 = new Token(DateTime.Now, TokenType.Datetime);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
}