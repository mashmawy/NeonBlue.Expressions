using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MultiplyOperatorsTests;

public class LongMultiplyOperatorUnitTest
{
    [Fact]
    public void LongMultiplyFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token((byte)2, TokenType.Byte);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(4, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void LongMultiplyIntegerFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token((long)2, TokenType.Long);
        var operand2 = new Token((long)2, TokenType.Integer);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(4, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongMultiplyLongFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(4, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void LongMultiplyFloatFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(4, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongMultiplyDecimalFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void LongMultiplyDoubleFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    } 
    [Fact]
    public void LongMultiplyNullFunctionDefaultOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void LongMultiplyNullFunctionPropgateOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void LongMultiplyNullFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        { 
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void LongMultiplyOtherTypesFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Long);
        var operand2 = new Token("545",TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        { 
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}