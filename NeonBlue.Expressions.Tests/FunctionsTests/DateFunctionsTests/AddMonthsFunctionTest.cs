using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class AddMonthsFunctionTest
{
    [Fact]
    public void AddMonthsFunctionReturnCorrectValueAndValueType()
    {
        AddMonthsFunction addMonthsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));
        tokens.Push(new Token(1, TokenType.Integer));

        addMonthsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Datetime);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(DateTime), result.Value.GetType());
        Assert.Equal(DateTime.Today.AddMonths(1), Convert.ToDateTime(result.Value));
    }

    [Fact]
    public void AddMonthsFunctionThrowForEmptyStackArgument()
    {
        AddMonthsFunction addMonthsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackException>(() =>
        {
            addMonthsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddMonthsFunctionThrowForInvalidArgument()
    {
        AddMonthsFunction addMonthsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeException>(() =>
        {
            addMonthsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddMonthsFunctionReturnNull()
    {
        AddMonthsFunction addMonthsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addMonthsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void AddMonthsFunctionThrowForNull()
    {
        AddMonthsFunction addMonthsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            addMonthsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void AddMonthsFunctionReturnDefaultForNull()
    {

        AddMonthsFunction addMonthsFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addMonthsFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}