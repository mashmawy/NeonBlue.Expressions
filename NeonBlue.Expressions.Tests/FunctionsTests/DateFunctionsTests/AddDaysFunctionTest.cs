using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class AddDaysFunctionTest
{
    [Fact]
    public void AddDaysFunctionReturnCorrectValueAndValueType()
    {
        AddDaysFunction addDaysFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));
        tokens.Push(new Token(1, TokenType.Integer));

        addDaysFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Datetime);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(DateTime), result.Value.GetType());
        Assert.Equal(DateTime.Today.AddDays(1), Convert.ToDateTime(result.Value));
    }

    [Fact]
    public void AddDaysFunctionThrowForEmptyStackArgument()
    {
        AddDaysFunction addDaysFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackException>(() =>
        {
            addDaysFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddDaysFunctionThrowForInvalidArgument()
    {
        AddDaysFunction addDaysFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            addDaysFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddDaysFunctionReturnNull()
    {
        AddDaysFunction addDaysFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addDaysFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void AddDaysFunctionThrowForNull()
    {
        AddDaysFunction addDaysFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            addDaysFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void AddDaysFunctionReturnDefaultForNull()
    {

        AddDaysFunction addDaysFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addDaysFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}