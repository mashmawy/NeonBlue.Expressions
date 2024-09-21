using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CDateFunctionTest
{
     

    [Fact]
    public void CDateTimeFunctionThrowCastingExceptionOnNoneDasteValues()
    {
        CDateTimeFunction CDateTimeFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(false, TokenType.Boolean));
        Assert.Throws<CastingException>(() =>
        {
            CDateTimeFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDateTimeFunctionReturnCorrectValueAndValueType()
    {
        CDateTimeFunction CDateTimeFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("1/1/2001", TokenType.String));
        CDateTimeFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Datetime);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(DateTime), result.Value.GetType());
        Assert.Equal(new DateTime(2001,1,1, 0, 0, 0, DateTimeKind.Utc), Convert.ToDateTime(result.Value));
    }

    [Fact]
    public void CDateTimeFunctionReturnNull()
    {
        CDateTimeFunction CDateTimeFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        CDateTimeFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CDateTimeFunctionThrowForNull()
    {
        CDateTimeFunction CDateTimeFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            CDateTimeFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDateTimeFunctionReturnDefaultForNull()
    {
        CDateTimeFunction CDateTimeFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        CDateTimeFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);

    }

}