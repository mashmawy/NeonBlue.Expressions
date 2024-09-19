using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class MonthFunctionTest
{
    [Fact]
    public void MonthFunctionReturnCorrectValueAndValueType()
    {
        MonthFunction monthFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));

        monthFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(testVal.Month, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void DaysFunctionThrowForEmptyStackArgument()
    {
        MonthFunction monthFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackExecption>(() =>
        {
            monthFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DaysFunctionThrowForInvalidArgument()
    {
        MonthFunction monthFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            monthFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void MonthFunctionReturnNull()
    {
        MonthFunction monthFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        monthFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void MonthFunctionThrowForNull()
    {
        MonthFunction monthFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            monthFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void MonthFunctionReturnDefaultForNull()
    {

        MonthFunction monthFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        monthFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}