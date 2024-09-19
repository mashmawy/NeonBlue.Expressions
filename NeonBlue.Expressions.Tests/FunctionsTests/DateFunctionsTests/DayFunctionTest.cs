using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class DayFunctionTest
{
    [Fact]
    public void DayFunctionReturnCorrectValueAndValueType()
    {
        DayFunction dayFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));

        dayFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(DateTime.Today.Day, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void DaysFunctionThrowForEmptyStackArgument()
    {
        DayFunction dayFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackException>(() =>
        {
            dayFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DaysFunctionThrowForInvalidArgument()
    {
        DayFunction dayFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            dayFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DayFunctionReturnNull()
    {
        DayFunction dayFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        dayFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void DayFunctionThrowForNull()
    {
        DayFunction dayFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            dayFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void DayFunctionReturnDefaultForNull()
    {

        DayFunction dayFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        dayFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}