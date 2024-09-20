using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MinusOperatorsTests;

public class DecimalMinusOperatorUnitTest
{
    [Fact]
    public void DecimalMinusByteReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(18m, Convert.ToDecimal(result.Value));
    }

    [Fact]
    public void DecimalMinusIntegerFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMinusLongFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMinusFloatFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMinusDecimalFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMinusDoubleFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    } 
    [Fact]
    public void DecimalMinusNullFunctionDefaultOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DecimalMinusNullFunctionPropgateOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DecimalMinusNullFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DecimalMinusOtherTypesFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Decimal);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}