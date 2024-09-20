using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CFloatFunctionTest
{
 

    [Fact]
    public void CFloatFunctionThrowCastingExceptionOnNoneNumericalValues()
    {
        CFloatFunction cFloatFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        Assert.Throws<CastingException>(() =>
        {
            cFloatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CFloatFunctionReturnCorrectValueAndValueType()
    {
        CFloatFunction cFloatFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("30", TokenType.String));
        cFloatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Float);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(float), result.Value.GetType());
        Assert.Equal(30, Convert.ToSingle(result.Value));
    }

    [Fact]
    public void CFloatFunctionReturnNull()
    {
        CFloatFunction cFloatFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cFloatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CFloatFunctionThrowForNull()
    {
        CFloatFunction cFloatFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            cFloatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CFloatFunctionReturnDefaultForNull()
    {
        CFloatFunction cFloatFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cFloatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Float);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(float), result.Value.GetType());
        Assert.Equal(0, Convert.ToSingle(result.Value));

    }

}