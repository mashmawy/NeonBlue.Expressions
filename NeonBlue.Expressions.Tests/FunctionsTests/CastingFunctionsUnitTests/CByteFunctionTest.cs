using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.CastingFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.CastingFunctionsUnitTests;

public class CByteFunctionTest
{
    [Fact]
    public void CByteFunctionThrowCastingExceptionOnLargeValues()
    {
        CByteFunction cByteFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(int.MaxValue, TokenType.Integer));
        Assert.Throws<CastingException>(() =>
        {
            cByteFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CByteFunctionThrowCastingExceptionOnNoneNumericalValues()
    {
        CByteFunction cByteFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        Assert.Throws<CastingException>(() =>
        {
            cByteFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CByteFunctionReturnCorrectValueAndValueType()
    {
        CByteFunction cByteFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token("30", TokenType.String));
        cByteFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Byte);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(byte), result.Value.GetType());
        Assert.Equal(30, Convert.ToByte(result.Value));
    }

    [Fact]
    public void CByteFunctionReturnNull()
    {
        CByteFunction cByteFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cByteFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.NULL);
        Assert.Null(result.Value);
    }
    [Fact]
    public void CByteFunctionThrowForNull()
    {
        CByteFunction cByteFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        Assert.Throws<NullTokenExecption>(() =>
        {
            cByteFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
        });
    }

    [Fact]
    public void CByteFunctionReturnDefaultForNull()
    {
        CByteFunction cByteFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null));
        cByteFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
        Assert.Single(tokens);
        var result = tokens.Pop();
        Assert.True(result.TokenType == TokenType.Byte);
            Assert.NotNull(result.Value);
        Assert.Equal(typeof(byte), result.Value.GetType());
        Assert.Equal((byte)0, Convert.ToByte(result.Value));

    }

}