using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class UpperFunctionUnitTests
    {
        [Fact]
        public void UpperFunctionReturnCorrectValueAndValueType()
        {

            UpperFunction upperFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("MohAmed", TokenType.String));
            upperFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("MOHAMED", Convert.ToString(result.Value));
        }


         [Fact]
        public void UpperFunctionThrowForEmptyStackArgument()
        {
            UpperFunction upperFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             upperFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void UpperFunctionReturnNull()
        {
            UpperFunction upperFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            upperFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void UpperFunctionThrowForNull()
        {
            UpperFunction upperFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                upperFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void UpperFunctionReturnDefaultForNull()
        {
            UpperFunction upperFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            upperFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}