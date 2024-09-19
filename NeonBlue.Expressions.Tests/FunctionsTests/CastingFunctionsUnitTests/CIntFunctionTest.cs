using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CIntFunctionTest
{
    [Fact]
    public void CIntFunctionThrowCastingExceptionOnLargeValues()
    {
        CIntFunction cIntFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(double.MaxValue, TokenType.Double));
        Assert.Throws<CastingException>(() =>
        {
            cIntFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CIntFunctionThrowCastingExceptionOnNoneNumericalValues()
    {
        CIntFunction cIntFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        Assert.Throws<CastingException>(() =>
        {
            cIntFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CIntFunctionReturnCorrectValueAndValueType()
    {
        CIntFunction cIntFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("30", TokenType.String));
        cIntFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(30, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void CIntFunctionReturnNull()
    {
        CIntFunction cIntFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cIntFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CIntFunctionThrowForNull()
    {
        CIntFunction cIntFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            cIntFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CIntFunctionReturnDefaultForNull()
    {
        CIntFunction cIntFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cIntFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(0, Convert.ToInt32(result.Value));

    }

}