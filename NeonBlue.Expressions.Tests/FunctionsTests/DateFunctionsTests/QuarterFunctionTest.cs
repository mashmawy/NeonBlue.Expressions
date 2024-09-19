using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class QuarterFunctionTest
{
    [Fact]
    public void QuarterFunctionReturnCorrectValueAndValueType()
    {
        QuarterFunction quarterFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));

        quarterFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(GetQuarter(testVal), Convert.ToInt32(result.Value));
    }
    private static int GetQuarter(DateTime dateTime)
    {

        if (dateTime.Month is >= 1 and <= 3)
        {
            return 1;
        }
        else if (dateTime.Month is >= 4 and <= 6)
        {
            return 2;
        }
        else if (dateTime.Month is >= 7 and <= 9)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }
    [Fact]
    public void QuarterFunctionThrowForEmptyStackArgument()
    {
        QuarterFunction quarterFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackExecption>(() =>
        {
            quarterFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void QuarterFunctionThrowForInvalidArgument()
    {
        QuarterFunction quarterFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            quarterFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void QuarterFunctionReturnNull()
    {
        QuarterFunction quarterFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        quarterFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void QuarterFunctionThrowForNull()
    {
        QuarterFunction quarterFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            quarterFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void QuarterFunctionReturnDefaultForNull()
    {

        QuarterFunction quarterFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        quarterFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}