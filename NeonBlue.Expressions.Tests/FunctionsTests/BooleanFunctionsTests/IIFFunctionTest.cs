using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.BooleanFunctionsTests;

public class IIFFunctionTest
{
    [Fact]
    public void IIFFunctionUnitTrueConditionTest()
    {
        IIFFunction iIFFunction = new();
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
        IIFFunction iIFFunction = new();
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
        IIFFunction iIFFunction
         = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(null, TokenType.NULL));
        tokens.Push(new Token(true, TokenType.Boolean));
        tokens.Push(new Token(10, TokenType.Integer));

        Assert.Throws<NullTokenExecption>(() => iIFFunction
        .Update(tokens, new ExecutionOptions(NullStrategy.Throw)));


    }
    [Fact]
    public void IIFFunctionShouldThrowEmptyStackExeception()
    {
        IIFFunction iIFFunction
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
        IIFFunction iIFFunction
         = new();
        Stack<Token> tokens = new();
        tokens.Push(new Token(DateTime.Now, TokenType.Datetime));
        tokens.Push(new Token(10, TokenType.Integer));
        tokens.Push(new Token(true, TokenType.Boolean));

        Assert.Throws<InvalidArgumentTypeExeception>(() => iIFFunction
        .Update(tokens, new ExecutionOptions(NullStrategy.Throw)));


    }

}