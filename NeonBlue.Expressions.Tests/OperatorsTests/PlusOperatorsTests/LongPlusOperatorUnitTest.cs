using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.PlusOperatorsTests;

public class LongPlusOperatorUnitTest
{
    [Fact]
    public void LongPlusFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(20, TokenType.Long);
        var operand2 = new Token((byte)2, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(22, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void LongPlusIntegerFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(220, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongPlusLongFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token((long)20, TokenType.Long);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Long);
        Assert.True(result.Value.GetType() == typeof(long));
        Assert.Equal(220, Convert.ToInt64(result.Value));
    }
    [Fact]
    public void LongPlusFloatFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Float);
        Assert.True(result.Value.GetType() == typeof(float));
        Assert.Equal(220, Convert.ToSingle(result.Value));
    }
    [Fact]
    public void LongPlusDecimalFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Decimal);
        Assert.True(result.Value.GetType() == typeof(decimal));
        Assert.Equal(220m, Convert.ToDecimal(result.Value));
    }
    [Fact]
    public void LongPlusDoubleFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Double);
        Assert.True(result.Value.GetType() == typeof(double));
        Assert.Equal(220.0, Convert.ToDouble(result.Value));
    } 
    [Fact]
    public void LongPlusNullFunctionDefaultOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void LongPlusNullFunctionPropgateOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void LongPlusNullFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenExecption>(() =>
        { 
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    
    

    

    [Fact]
    public void LongPlusStringReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token("545", TokenType.String);
        var result =
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value.GetType() == typeof(string));
        Assert.Equal("200545", Convert.ToString(result.Value));
    }

    [Fact]
    public void LongPlusOtherTypesFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token(200, TokenType.Long);
        var operand2 = new Token(DateTime.Now, TokenType.Datetime);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}