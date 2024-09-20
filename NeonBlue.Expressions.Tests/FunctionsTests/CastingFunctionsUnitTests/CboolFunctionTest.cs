using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CBoolFunctionTest
{
    [Fact]
    public void CBoolFunctionReturnFalseForZeroValueTest()
    {
        CBoolFunction cboolFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(0, TokenType.Integer));
        cboolFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Boolean);
        Assert.False(Convert.ToBoolean(result.Value));
    }
    [Fact]
    public void CBoolFunctionReturnTrueForNoneZeroValueTest()
    {
        CBoolFunction cboolFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(23, TokenType.Integer));
        cboolFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Boolean);
        Assert.True(Convert.ToBoolean(result.Value));
    }

    [Fact]
    public void CBoolFunctionReturnNull()
    {
        CBoolFunction cboolFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cboolFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CBoolFunctionThrowForNull()
    {
        CBoolFunction cboolFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            cboolFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        }); 
    }

    [Fact]
    public void CBoolFunctionReturnDefaultForNull()
    {
        CBoolFunction cboolFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cboolFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Boolean);
        Assert.False(Convert.ToBoolean(result.Value));

    }

}