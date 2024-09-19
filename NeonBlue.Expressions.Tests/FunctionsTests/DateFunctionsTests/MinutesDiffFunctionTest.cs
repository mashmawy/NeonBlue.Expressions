using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class MinutesDiffFunctionTest
{
    [Fact]
    public void MinutesDiffFunctionReturnCorrectValueAndValueType()
    {
        MinutesDiffFunction minuteDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today.AddMinutes(1), TokenType.Datetime));
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));

        minuteDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Double);
        Assert.NotNull(result.Value);
        Assert.Equal(typeof(double), result.Value.GetType());
        Assert.Equal(1, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void MinuteDiffsFunctionThrowForEmptyStackArgument()
    {
        MinutesDiffFunction minuteDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackExecption>(() =>
        {
            minuteDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void MinuteDiffsFunctionThrowForInvalidArgument()
    {
        MinutesDiffFunction minuteDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            minuteDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void MinutesDiffFunctionReturnNull()
    {
        MinutesDiffFunction minuteDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        minuteDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void MinutesDiffFunctionThrowForNull()
    {
        MinutesDiffFunction minuteDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            minuteDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void MinutesDiffFunctionReturnDefaultForNull()
    {

        MinutesDiffFunction minuteDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        minuteDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}