
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class SubstringFunctionUnitTests
    {
        [Fact]
        public void SubstringFunctionReturnCorrectValueAndValueType()
        {

            SubstringFunction substringFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed hassan ahmed", TokenType.String));
            tokens.Push(new Token(8, TokenType.Integer));
            tokens.Push(new Token(6, TokenType.Integer));
            substringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("hassan", Convert.ToString(result.Value));
        }


         [Fact]
        public void SubstringFunctionThrowForEmptyStackArgument()
        {
            SubstringFunction substringFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             substringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void SubstringFunctionReturnNull()
        {
            SubstringFunction substringFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            substringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void SubstringFunctionThrowForNull()
        {
            SubstringFunction substringFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                substringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void SubstringFunctionReturnDefaultForNull()
        {
            SubstringFunction substringFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            substringFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}