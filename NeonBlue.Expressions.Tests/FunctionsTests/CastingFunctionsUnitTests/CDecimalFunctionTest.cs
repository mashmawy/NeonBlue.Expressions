using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CDecimalFunctionTest
{
    [Fact]
    public void CDecimalFunctionThrowCastingExceptionOnLargeValues()
    {
        CDecimalFunction CDecimalFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(double.MaxValue, TokenType.Double));
        Assert.Throws<CastingException>(() =>
        {
            CDecimalFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDecimalFunctionThrowCastingExceptionOnNoneNumericalValues()
    {
        CDecimalFunction CDecimalFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        Assert.Throws<CastingException>(() =>
        {
            CDecimalFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDecimalFunctionReturnCorrectValueAndValueType()
    {
        CDecimalFunction CDecimalFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("30", TokenType.String));
        CDecimalFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Decimal);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(decimal), result.Value.GetType());
        Assert.Equal(30m, Convert.ToDecimal(result.Value));
    }

    [Fact]
    public void CDecimalFunctionReturnNull()
    {
        CDecimalFunction CDecimalFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        CDecimalFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CDecimalFunctionThrowForNull()
    {
        CDecimalFunction CDecimalFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenException>(() =>
        {
            CDecimalFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CDecimalFunctionReturnDefaultForNull()
    {
        CDecimalFunction CDecimalFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        CDecimalFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Decimal);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(decimal), result.Value.GetType());
        Assert.Equal(0m, Convert.ToDecimal(result.Value));

    }

}