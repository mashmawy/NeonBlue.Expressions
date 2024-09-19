using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MultiplyOperatorsTests;

public class DecimalMultiplyOperatorUnitTest
{
    [Fact]
    public void DecimalMultiplyByteReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }

    [Fact]
    public void DecimalMultiplyIntegerFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMultiplyLongFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMultiplyFloatFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMultiplyDecimalFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void DecimalMultiplyDoubleFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
  
    [Fact]
    public void DecimalMultiplyNullFunctionDefaultOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void DecimalMultiplyNullFunctionPropgateOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void DecimalMultiplyNullFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        {
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DecimalMultiplyOtherTypesFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2m, TokenType.Decimal);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}