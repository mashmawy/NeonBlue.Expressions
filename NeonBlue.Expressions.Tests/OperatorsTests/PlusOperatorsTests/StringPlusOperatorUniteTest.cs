using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.PlusOperatorsTests;

public class StringPlusOperatorUnitTest
{
    [Fact]
    public void StringPlusFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token((byte)20, TokenType.Byte);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
        Assert.Equal("123b20", Convert.ToString(result.Value));
    }

    [Fact]
    public void StringPlusIntegerFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(20, TokenType.Integer);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
        Assert.Equal("123b20", Convert.ToString(result.Value));
    } 
    [Fact]
    public void StringPlusFloatFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(20f, TokenType.Float);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
        Assert.Equal("123b20", Convert.ToString(result.Value));
    }
    [Fact]
    public void StringPlusDecimalFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(20m, TokenType.Decimal);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
       Assert.Equal("123b20", Convert.ToString(result.Value));
    }
    [Fact]
    public void StringPlusDoubleFunctionReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(20.0, TokenType.Double);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
      Assert.Equal("123b20", Convert.ToString(result.Value));
    } 
    [Fact]
    public void StringPlusNullFunctionDefaultOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }
    [Fact]
    public void StringPlusNullFunctionPropgateOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(null, TokenType.NULL);
        var result =
         divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

        Assert.Null(result.Value);
        Assert.True(result.TokenType == TokenType.NULL);
    }

    [Fact]
    public void StringPlusNullFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(null, TokenType.NULL);
        Assert.Throws<NullTokenException>(() =>
        { 
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    
    

    

    [Fact]
    public void StringPlusStringReturnCorrectValueAndValueType()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token("545", TokenType.String);
        var result =
           divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.String);
        Assert.True(result.Value is string);
        Assert.Equal("123b545", Convert.ToString(result.Value));
    }

    [Fact]
    public void StringPlusOtherTypesFunctionThrowOption()
    {
        PlusOperatorOverloads divideOperatorOverloads = new();
        var operand1 = new Token("123b", TokenType.String);
        var operand2 = new Token(DateTime.Now, TokenType.Datetime);
        Assert.Throws<InvalidOperationException>(() =>
        {
            divideOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
        });
    }

}