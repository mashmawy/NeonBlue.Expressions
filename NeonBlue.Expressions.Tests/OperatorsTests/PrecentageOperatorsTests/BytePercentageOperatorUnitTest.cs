using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;
namespace NeonBlue.Expressions.Tests.OperatorsTests.PrecentageOperatorsTests;

public class BytePercentageOperatorUnitTest
{
    [Fact]
    public void BytePercentageFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.True(result.Value.GetType() == typeof(int));
        Assert.Equal(1, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void BytePercentageIntegerFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(2, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.True(result.Value.GetType() == typeof(int));
        Assert.Equal(1, Convert.ToInt32(result.Value));
    }
    [Fact]
    public void BytePercentageLongFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token((long)2, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(1, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void BytePercentageFloatFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(2f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(1, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void BytePercentageDecimalFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(2m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(1m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void BytePercentageDoubleFunctionReturnCorrectValueAndValueType()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(2.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(1.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void BytePercentageNullFunctionDefaultOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void BytePercentageNullFunctionPropgateOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void BytePercentageNullFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void BytePercentageOtherTypesFunctionThrowOption()
    {
        PercentageOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(3, TokenType.Byte);
        var operand2 = new Token("545", TokenType.String);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}