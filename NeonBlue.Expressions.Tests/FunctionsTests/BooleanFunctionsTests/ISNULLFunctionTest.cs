using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.BooleanFunctionsTests;

public class ISNULLFunctionTest
{
    [Fact]
    public void ISNULLFunctionUnitFalseConditionTest()
    {
        ISNULLFunction isnullFunction = new();
        Stack<Token> tokens = new(); 
        tokens.Push(new Token(10, TokenType.Integer)); 

        isnullFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));


        Assert.Single(tokens);
        var result=tokens.Pop();
        Assert.True( result.TokenType== TokenType.Boolean);
        Assert.False( Convert.ToBoolean(result.Value));

    } 
    [Fact]
    public void ISNULLFunctionUnitTrueConditionTest()
    {
        ISNULLFunction isnullFunction = new();
        Stack<Token> tokens = new(); 
        tokens.Push(new Token(null, TokenType.NULL)); 

        isnullFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));


        Assert.Single(tokens);
        var result=tokens.Pop();
        Assert.True( result.TokenType== TokenType.Boolean);
        Assert.True( Convert.ToBoolean(result.Value));

    } 

}