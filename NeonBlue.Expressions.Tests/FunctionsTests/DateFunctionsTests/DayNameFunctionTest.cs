using System.Globalization;
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class DayNameFunctionTest
{
    [Fact]
    public void DayNameFunctionReturnCorrectValueAndValueType()
    {
        DayNameFunction dayNameFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));
        tokens.Push(new Token("en", TokenType.String));

        dayNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.String);
        Assert.NotNull(result.Value);
        Assert.Equal(typeof(string), result.Value.GetType());
        Assert.Equal(testVal.ToString("dddd", CultureInfo.CreateSpecificCulture("en")), Convert.ToString(result.Value));
    }

    [Fact]
    public void DaysFunctionThrowForEmptyStackArgument()
    {
        DayNameFunction dayNameFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackException>(() =>
        {
            dayNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DaysFunctionThrowForInvalidArgument()
    {
        DayNameFunction dayNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            dayNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DayNameFunctionReturnNull()
    {
        DayNameFunction dayNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        dayNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void DayNameFunctionThrowForNull()
    {
        DayNameFunction dayNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            dayNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void DayNameFunctionReturnDefaultForNull()
    {

        DayNameFunction dayNameFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        dayNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}