using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class ConcatFunctionUnitTests
    {
        [Fact]
        public void ConcatFunctionReturnCorrectValueAndValueType()
        {

            ConcatFunction concatFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed", TokenType.String));
            tokens.Push(new Token(" hassan", TokenType.String));
            concatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("mohamed hassan", Convert.ToString(result.Value));
        }


         [Fact]
        public void ConcatFunctionThrowForEmptyStackArgument()
        {
            ConcatFunction concatFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             concatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void ConcatFunctionReturnNull()
        {
            ConcatFunction concatFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            concatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void ConcatFunctionThrowForNull()
        {
            ConcatFunction concatFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                concatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void ConcatFunctionReturnDefaultForNull()
        {
            ConcatFunction concatFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            concatFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}