using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CStringFunctionTest
{
    [Fact]
    public void CStringFunctionReturnFalseForZeroValueTest()
    {
        CStringFunction cstringFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(0, TokenType.Integer));
        cstringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.String);
        Assert.Equal("0", Convert.ToString(result.Value));
    }
 

    [Fact]
    public void CStringFunctionReturnNull()
    {
        CStringFunction cstringFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cstringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CStringFunctionThrowForNull()
    {
        CStringFunction cstringFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            cstringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        }); 
    }

    [Fact]
    public void CStringFunctionReturnDefaultForNull()
    {
        CStringFunction cstringFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cstringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Equal( "",Convert.ToString(result.Value));

    }

}