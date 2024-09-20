using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests;

public class AddHoursFunctionTest
{
    [Fact]
    public void AddHoursFunctionReturnCorrectValueAndValueType()
    {
        AddHoursFunction addHoursFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Today, TokenType.Datetime));
        tokens.Push(new Token(1, TokenType.Integer));

        addHoursFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Datetime);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(DateTime), result.Value.GetType());
        Assert.Equal(DateTime.Today.AddHours(1), Convert.ToDateTime(result.Value));
    }

    [Fact]
    public void AddHoursFunctionThrowForEmptyStackArgument()
    {
        AddHoursFunction addHoursFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<EmptyStackException>(() =>
        {
            addHoursFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddHoursFunctionThrowForInvalidArgument()
    {
        AddHoursFunction addHoursFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("hello"));
        tokens.Push(new Token("this is invalid"));
        Assert.Throws<InvalidArgumentTypeException>(() =>
        {
            addHoursFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }
    [Fact]
    public void AddHoursFunctionReturnNull()
    {
        AddHoursFunction addHoursFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addHoursFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void AddHoursFunctionThrowForNull()
    {
        AddHoursFunction addHoursFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            addHoursFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void AddHoursFunctionReturnDefaultForNull()
    {

        AddHoursFunction addHoursFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        tokens.Push(new Token(null));
        addHoursFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}