using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class HourDiffFunctionTest
{
    [Fact]
    public void HourDiffFunctionReturnCorrectValueAndValueType()
    {
        HourDiffFunction hourDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today.AddHours(1), TokenType.Datetime));
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));

        hourDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Double);
        Assert.NotNull(result.Value);
        Assert.Equal(typeof(double), result.Value.GetType());
        Assert.Equal(1, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void HourDiffsFunctionThrowForEmptyStackArgument()
    {
        HourDiffFunction hourDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackExecption>(() =>
        {
            hourDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void HourDiffsFunctionThrowForInvalidArgument()
    {
        HourDiffFunction hourDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            hourDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void HourDiffFunctionReturnNull()
    {
        HourDiffFunction hourDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        hourDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void HourDiffFunctionThrowForNull()
    {
        HourDiffFunction hourDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            hourDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void HourDiffFunctionReturnDefaultForNull()
    {

        HourDiffFunction hourDiffFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        hourDiffFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}