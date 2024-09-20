using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.BooleanFunctionsTests;

public class NotFunctionTest
{
    [Fact]
    public void ISNULLFunctionUnitFalseConditionTest()
    {
        NotFunction notFunction = new();
        Stack<Token> tokens = new(); 
        tokens.Push(new Token(10, TokenType.Integer)); 

        notFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));


        Assert.Single(tokens);
        var result=tokens.Pop();
        Assert.True( result.TokenType== TokenType.Boolean);
        Assert.False( Convert.ToBoolean(result.Value));

    } 
    [Fact]
    public void ISNULLFunctionUnitTrueConditionTest()
    {
        NotFunction notFunction = new();
        Stack<Token> tokens = new(); 
        tokens.Push(new Token(false, TokenType.Boolean)); 

        notFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));


        Assert.Single(tokens);
        var result=tokens.Pop();
        Assert.True( result.TokenType== TokenType.Boolean);
        Assert.True( Convert.ToBoolean(result.Value));

    } 

}