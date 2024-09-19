using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CLongFunctionTest
{
    [Fact]
    public void CLongFunctionThrowCastingExceptionOnLargeValues()
    {
        CLongFunction cLongFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(double.MaxValue, TokenType.Double));
        Assert.Throws<CastingException>(() =>
        {
            cLongFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CLongFunctionThrowCastingExceptionOnNoneNumericalValues()
    {
        CLongFunction cLongFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        Assert.Throws<CastingException>(() =>
        {
            cLongFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CLongFunctionReturnCorrectValueAndValueType()
    {
        CLongFunction cLongFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("30", TokenType.String));
        cLongFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Long);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(long), result.Value.GetType());
        Assert.Equal(30, Convert.ToInt64(result.Value));
    }

    [Fact]
    public void CLongFunctionReturnNull()
    {
        CLongFunction cLongFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cLongFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CLongFunctionThrowForNull()
    {
        CLongFunction cLongFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            cLongFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CLongFunctionReturnDefaultForNull()
    {
        CLongFunction cLongFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cLongFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Long);

            Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(0, Convert.ToInt64(result.Value));

    }

}