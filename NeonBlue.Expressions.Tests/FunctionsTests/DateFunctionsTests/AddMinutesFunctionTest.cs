using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class AddMinutesFunctionTest
{
    [Fact]
    public void AddMinutesFunctionReturnCorrectValueAndValueType()
    {
        AddMinutesFunction addMinutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));
        tokens.Push(new Token(1, TokenType.Integer));

        addMinutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Datetime);
        Assert.NotNull(result.Value);
        Assert.Equal(typeof(DateTime), result.Value.GetType());
        Assert.Equal(DateTime.Today.AddMinutes(1), Convert.ToDateTime(result.Value));
    }

    [Fact]
    public void AddMinutesFunctionThrowForEmptyStackArgument()
    {
        AddMinutesFunction addMinutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackException>(() =>
        {
            addMinutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddMinutesFunctionThrowForInvalidArgument()
    {
        AddMinutesFunction addMinutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeException>(() =>
        {
            addMinutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddMinutesFunctionReturnNull()
    {
        AddMinutesFunction addMinutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addMinutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void AddMinutesFunctionThrowForNull()
    {
        AddMinutesFunction addMinutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            addMinutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void AddMinutesFunctionReturnDefaultForNull()
    {

        AddMinutesFunction addMinutesFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addMinutesFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}