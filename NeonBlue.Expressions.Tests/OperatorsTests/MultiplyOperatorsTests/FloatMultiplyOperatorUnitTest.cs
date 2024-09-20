using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MultiplyOperatorsTests;

public class FloatMultiplyOperatorUnitTest
{
    [Fact]
    public void FloatMultiplyByteReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(4f, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void FloatMultiplyIntegerFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(4f, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatMultiplyLongFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(4f, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void FloatMultiplyDoubleFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }
    [Fact]
    public void FloatMultiplyDecimalFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void FloatMultiplyFloatFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(4f, Convert.ToSingle(result.Value));
    }
   
    [Fact]
    public void FloatMultiplyNullFunctionDefaultOption()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void FloatMultiplyNullFunctionPropgateOption()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void FloatMultiplyNullFunctionThrowOption()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void FloatMultiplyOtherTypesFunctionThrowOption()
    {
        MultiplyOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(2f, TokenType.Float);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}