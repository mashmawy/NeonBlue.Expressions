using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class QuarterNameFunctionTest
{
    [Fact]
    public void QuarterNameFunctionReturnCorrectValueAndValueType()
    {
        QuarterNameFunction quarterNameFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));

        quarterNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(string), result.Value.GetType());
        Assert.Equal(GetQuarterName(testVal), Convert.ToString(result.Value));
    }

    private string GetQuarterName(DateTime dateTime)
    {

        if (dateTime.Month is >= 1 and <= 3)
        {
            return "Q1";
        }
        else if (dateTime.Month is >= 4 and <= 6)
        {
            return "Q2";
        }
        else if (dateTime.Month is >= 7 and <= 9)
        {
            return "Q3";
        }
        else
        {
            return "Q4";
        }
    }
    [Fact]
    public void QuartersFunctionThrowForEmptyStackArgument()
    {
        QuarterNameFunction quarterNameFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackExecption>(() =>
        {
            quarterNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void QuartersFunctionThrowForInvalidArgument()
    {
        QuarterNameFunction quarterNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            quarterNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void QuarterNameFunctionReturnNull()
    {
        QuarterNameFunction quarterNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        quarterNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void QuarterNameFunctionThrowForNull()
    {
        QuarterNameFunction quarterNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            quarterNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void QuarterNameFunctionReturnDefaultForNull()
    {

        QuarterNameFunction quarterNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        quarterNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}