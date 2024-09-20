using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.MultiplyOperatorsTests;

public class IntegerMultiplyOperatorUnitTest
{
    [Fact]
    public void IntegerMultiplyFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token((byte)2, TokenType.Byte);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.True(result.Value is int);
        Assert.Equal(4, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void IntegerMultiplyIntegerFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.True(result.Value is int);
        Assert.Equal(4, Convert.ToInt32(result.Value));
    }
    [Fact]
    public void IntegerMultiplyLongFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value is long);
        Assert.Equal(4, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void IntegerMultiplyFloatFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value is float);
        Assert.Equal(4, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void IntegerMultiplyDecimalFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value is decimal);
        Assert.Equal(4m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void IntegerMultiplyDoubleFunctionReturnCorrectValueAndValueType()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value is double);
        Assert.Equal(4.0, Convert.ToDouble(result.Value));
    }
    
    [Fact]
    public void IntegerMultiplyNullFunctionDefaultOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void IntegerMultiplyNullFunctionPropgateOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void IntegerMultiplyNullFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        { 
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void IntegerMultiplyOtherTypesFunctionThrowOption()
    {
        MultiplyOperatorOverloads multiplyOperatorOverloads = new();
        var operand1 = new Token(2, TokenType.Integer);
        var operand2 = new Token("545",TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        { 
            multiplyOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}