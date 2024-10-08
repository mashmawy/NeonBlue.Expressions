using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.BooleanFunctionsTests;

public class IIFFunctionTest
{
    [Fact]
    public void IIFFunctionUnitTrueConditionTest()
    {
        IifFunction iIFFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(true, TokenType.Boolean));
        tokens.Push(new Token(10, TokenType.Integer));
        tokens.Push(new Token(true, TokenType.Boolean));

        iIFFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));


        Assert.Single(tokens);

        Assert.Equal(10, Convert.ToInt32(tokens.Pop().Value));

    }
    [Fact]
    public void IIFFunctionUnitFalseConditionTest()
    {
        IifFunction iIFFunction = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(false, TokenType.Boolean));
        tokens.Push(new Token(10, TokenType.Integer));
        tokens.Push(new Token(true, TokenType.Boolean));

        iIFFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));


        Assert.Single(tokens);

        Assert.True(Convert.ToBoolean(tokens.Pop().Value));

    }
    [Fact]
    public void IIFFunctionShouldThrowNullExeception()
    {
        IifFunction iIFFunction
         = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null, TokenType.NULL));
        tokens.Push(new Token(true, TokenType.Boolean));
        tokens.Push(new Token(10, TokenType.Integer));

        Assert.Throws<NullTokenException>(() => iIFFunction
        .Update(tokens, new ExecutionOptions(NullStrategy.Throw)));


    }
    [Fact]
    public void IIFFunctionShouldThrowEmptyStackExeception()
    {
        IifFunction iIFFunction
         = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(true, TokenType.Boolean));
        tokens.Push(new Token(10, TokenType.Integer));

        Assert.Throws<EmptyStackException>(() => iIFFunction
        .Update(tokens, new ExecutionOptions(NullStrategy.Throw)));


    }
    [Fact]
    public void IIFFunctionShouldThrowInvalidArgumentTypeExeception()
    {
        IifFunction iIFFunction
         = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        tokens.Push(new Token(10, TokenType.Integer));
        tokens.Push(new Token(true, TokenType.Boolean));

        Assert.Throws<InvalidArgumentTypeException>(() => iIFFunction
        .Update(tokens, new ExecutionOptions(NullStrategy.Throw)));


    }

}