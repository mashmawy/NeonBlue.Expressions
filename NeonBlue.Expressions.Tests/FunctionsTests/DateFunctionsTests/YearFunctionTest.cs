using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class YearFunctionTest
{
    [Fact]
    public void YearFunctionReturnCorrectValueAndValueType()
    {
        YearFunction yearFunction = new();
        Stack<Token> tokens = new();
        var testVal = DateTime.Now;
        tokens.Push(new Token(testVal, TokenType.Datetime));

        yearFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Integer);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(int), result.Value.GetType());
        Assert.Equal(testVal.Year, Convert.ToInt32(result.Value));
    }

    [Fact]
    public void DaysFunctionThrowForEmptyStackArgument()
    {
        YearFunction yearFunction = new();
        Stack<Token> tokens = new();
        Assert.Throws<EmptyStackExecption>(() =>
        {
            yearFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void DaysFunctionThrowForInvalidArgument()
    {
        YearFunction yearFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        Assert.Throws<InvalidArgumentTypeExeception>(() =>
        {
            yearFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void YearFunctionReturnNull()
    {
        YearFunction yearFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        yearFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void YearFunctionThrowForNull()
    {
        YearFunction yearFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            yearFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void YearFunctionReturnDefaultForNull()
    {

        YearFunction yearFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        yearFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}