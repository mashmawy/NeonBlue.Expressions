using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class SecondsFunctionTest
{
    [Fact]
    public void SecondsFunctionReturnCorrectValueAndValueType()
    {
        SecondsFunction secondFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));

        secondFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(testVal.Second, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void DaysFunctionThrowForEmptyStackArgument()
    {
        SecondsFunction secondFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackException>(() =>
        {
            secondFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DaysFunctionThrowForInvalidArgument()
    {
        SecondsFunction secondFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            secondFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void SecondsFunctionReturnNull()
    {
        SecondsFunction secondFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        secondFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void SecondsFunctionThrowForNull()
    {
        SecondsFunction secondFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            secondFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void SecondsFunctionReturnDefaultForNull()
    { 
        SecondsFunction secondFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        secondFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}