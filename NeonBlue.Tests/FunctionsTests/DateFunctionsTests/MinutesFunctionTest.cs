using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class MinutesFunctionTest
{
    [Fact]
    public void MinutesFunctionReturnCorrectValueAndValueType()
    {
        MinutesFunction minutesFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));

        minutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.True(result.TokenType == TokenType.Integer);
        Assert.Equal(typeof(int), result!.Value.GetType());
        Assert.Equal(testVal.Minute, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void DaysFunctionThrowForEmptyStackArgument()
    {
        MinutesFunction minutesFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackExecption>(() =>
        {
            minutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DaysFunctionThrowForInvalidArgument()
    {
        MinutesFunction minutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            minutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void MinutesFunctionReturnNull()
    {
        MinutesFunction minutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        minutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void MinutesFunctionThrowForNull()
    {
        MinutesFunction minutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            minutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void MinutesFunctionReturnDefaultForNull()
    {

        MinutesFunction minutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        minutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}