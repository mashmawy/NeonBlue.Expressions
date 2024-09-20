
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MultiplyOperatorsTests;

public class DoubleMultiplyOperatorUnitTest
{
    [Fact]
    public void DoubleMultiplyByteReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DoubleMultiplyIntegerFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoubleMultiplyLongFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoubleMultiplyFloatFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void DoubleMultiplyDecimalFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DoubleMultiplyDoubleFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }
  
    [Fact]
    public void DoubleMultiplyNullFunctionDefaultOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DoubleMultiplyNullFunctionPropgateOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DoubleMultiplyNullFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DoubleMultiplyOtherTypesFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2.0, TokenType.Double);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}