using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MinusOperatorsTests;

public class LongMinusOperatorUnitTest
{
    [Fact]
    public void LongMinusFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20, TokenType.Long);
        var operand2 = new Token((byte)2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(18, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void LongMinusIntegerFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(180, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongMinusLongFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(180, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void LongMinusFloatFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(180, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongMinusDecimalFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void LongMinusDoubleFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(180.0, Convert.ToDouble(result.Value));
    } 
    [Fact]
    public void LongMinusNullFunctionDefaultOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void LongMinusNullFunctionPropgateOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void LongMinusNullFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        { 
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void LongMinusOtherTypesFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token("545",TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        { 
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}