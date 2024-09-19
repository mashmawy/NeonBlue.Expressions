using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class DayDiffFunctionTest
{
    [Fact]
    public void DayDiffFunctionReturnCorrectValueAndValueType()
    {
        DayDiffFunction dayDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today.AddDays(1), TokenType.Datetime));
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));

        dayDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(double), result.Value.GetType());
        Assert.Equal(1, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void DayDiffsFunctionThrowForEmptyStackArgument()
    {
        DayDiffFunction dayDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackException>(() =>
        {
            dayDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DayDiffsFunctionThrowForInvalidArgument()
    {
        DayDiffFunction dayDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            dayDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DayDiffFunctionReturnNull()
    {
        DayDiffFunction dayDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        dayDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void DayDiffFunctionThrowForNull()
    {
        DayDiffFunction dayDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            dayDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void DayDiffFunctionReturnDefaultForNull()
    { 
        DayDiffFunction dayDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        dayDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value); 
    }

}