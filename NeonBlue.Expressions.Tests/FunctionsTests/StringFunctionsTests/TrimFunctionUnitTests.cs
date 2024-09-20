using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class TrimFunctionUnitTests
    {
        [Fact]
        public void TrimFunctionReturnCorrectValueAndValueType()
        {

            TrimFunction trimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(" mohamed ", TokenType.String));
            trimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("mohamed", Convert.ToString(result.Value));
        }


         [Fact]
        public void TrimFunctionThrowForEmptyStackArgument()
        {
            TrimFunction trimFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             trimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void TrimFunctionReturnNull()
        {
            TrimFunction trimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            trimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void TrimFunctionThrowForNull()
        {
            TrimFunction trimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                trimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void TrimFunctionReturnDefaultForNull()
        {
            TrimFunction trimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            trimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}