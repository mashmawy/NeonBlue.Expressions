using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.BooleanFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.BooleanFunctionsTests;

public class OrFunctionTest
{
    [Fact]
    public void OrFunctionUnitTest()
    {
          OrFunction orFunction= new();
          Stack<Token> tokens= new();
          tokens.Push(new Token(true, TokenType.Boolean));
          tokens.Push(new Token(true, TokenType.Boolean));
          
          orFunction.Update(tokens,new ExecutionOptions(NullStrategy.Throw));
          

          Assert.Single(tokens);

          Assert.True(Convert.ToBoolean(tokens.Pop().Value));

    }
    [Fact]
    public void OrFunctionWithNullUnitTest()
    {
          OrFunction orFunction= new();
          Stack<Token> tokens= new();
          tokens.Push(new Token(true, TokenType.Boolean));
          tokens.Push(new Token(null, TokenType.NULL));
          
          orFunction.Update(tokens,new ExecutionOptions(NullStrategy.Default));
          

          Assert.Single(tokens);

          Assert.False(Convert.ToBoolean(tokens.Pop().Value));

    }
    [Fact]
    public void OrFunctionWithStringOrNumersUnitTest()
    {
          OrFunction orFunction= new();
          Stack<Token> tokens= new();
          tokens.Push(new Token("true", TokenType.String ));
          tokens.Push(new Token(1, TokenType.Integer));
          
          orFunction.Update(tokens,new ExecutionOptions(NullStrategy.Default));
          

          Assert.Single(tokens);

          Assert.True(Convert.ToBoolean(tokens.Pop().Value));

    }
}