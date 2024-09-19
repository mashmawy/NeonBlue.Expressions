using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.BooleanFunctionsTests;

public class AndFunctionTest
{
    [Fact]
    public void AndFunctionUnitTest()
    {
          AndFunction andFunction= new();
          Stack<Token> tokens= new();
          tokens.Push(new Token(true, TokenType.Boolean));
          tokens.Push(new Token(true, TokenType.Boolean));
          
          andFunction.Update(tokens,new ExecutionOptions(NullStrategy.Throw));
          

          Assert.Single(tokens);

          Assert.True(Convert.ToBoolean(tokens.Pop().Value));

    }
    [Fact]
    public void AndFunctionWithNullUnitTest()
    {
          AndFunction andFunction= new();
          Stack<Token> tokens= new();
          tokens.Push(new Token(true, TokenType.Boolean));
          tokens.Push(new Token(null, TokenType.NULL));
          
          andFunction.Update(tokens,new ExecutionOptions(NullStrategy.Default));
          

          Assert.Single(tokens);

          Assert.False(Convert.ToBoolean(tokens.Pop().Value));

    }
    [Fact]
    public void AndFunctionWithStringOrNumersUnitTest()
    {
          AndFunction andFunction= new();
          Stack<Token> tokens= new();
          tokens.Push(new Token("true", TokenType.String ));
          tokens.Push(new Token(1, TokenType.Integer));
          
          andFunction.Update(tokens,new ExecutionOptions(NullStrategy.Default));
          

          Assert.Single(tokens);

          Assert.True(Convert.ToBoolean(tokens.Pop().Value));

    }
}