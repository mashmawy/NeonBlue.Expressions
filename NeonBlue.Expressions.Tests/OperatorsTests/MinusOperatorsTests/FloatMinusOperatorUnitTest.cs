
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MinusOperatorsTests;

public class FloatMinusOperatorUnitTest
{
    [Fact]
    public void FloatMinusByteReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(18.0, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void FloatMinusIntegerFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(180f, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatMinusLongFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(180.0, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatMinusDoubleFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20f, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(180.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void FloatMinusDecimalFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(180m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void FloatMinusFloatFunctionReturnCorrectValueAndValueType()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(180f, Convert.ToSingle(result.Value));
    } 
    [Fact]
    public void FloatMinusNullFunctionDefaultOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void FloatMinusNullFunctionPropgateOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void FloatMinusNullFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void FloatMinusOtherTypesFunctionThrowOption()
    {
        MinusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200f, TokenType.Float);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}