using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CDoubleFunctionTest
{
     
    [Fact]
    public void CDoubleFunctionThrowCastingExceptionOnNoneNumericalValues()
    {
        CDoubleFunction CDoubleFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        Assert.Throws<CastingException>(() =>
        {
            CDoubleFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDoubleFunctionReturnCorrectValueAndValueType()
    {
        CDoubleFunction CDoubleFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("30", TokenType.String));
        CDoubleFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(double), result.Value.GetType());
        Assert.Equal(30.0, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void CDoubleFunctionReturnNull()
    {
        CDoubleFunction CDoubleFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        CDoubleFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CDoubleFunctionThrowForNull()
    {
        CDoubleFunction CDoubleFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            CDoubleFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDoubleFunctionReturnDefaultForNull()
    {
        CDoubleFunction CDoubleFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        CDoubleFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(double), result.Value.GetType());
        Assert.Equal(0.0, Convert.ToDouble(result.Value));

    }

}