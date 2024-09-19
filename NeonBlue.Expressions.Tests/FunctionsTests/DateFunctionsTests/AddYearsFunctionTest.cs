using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class AddYearsFunctionTest
{
    [Fact]
    public void AddYearsFunctionReturnCorrectValueAndValueType()
    {
        AddYearsFunction addYearsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));
        tokens.Push(new Token(1, TokenType.Integer));

        addYearsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Datetime);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(DateTime), result.Value.GetType());
        Assert.Equal(DateTime.Today.AddYears(1), Convert.ToDateTime(result.Value));
    }

    [Fact]
    public void AddYearsFunctionThrowForEmptyStackArgument()
    {
        AddYearsFunction addYearsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackExecption>(() =>
        {
            addYearsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddYearsFunctionThrowForInvalidArgument()
    {
        AddYearsFunction addYearsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            addYearsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddYearsFunctionReturnNull()
    {
        AddYearsFunction addYearsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addYearsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void AddYearsFunctionThrowForNull()
    {
        AddYearsFunction addYearsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            addYearsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void AddYearsFunctionReturnDefaultForNull()
    {

        AddYearsFunction addYearsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addYearsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}