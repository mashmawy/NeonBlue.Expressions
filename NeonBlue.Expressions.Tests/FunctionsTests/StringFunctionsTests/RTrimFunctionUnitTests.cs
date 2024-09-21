using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class RTrimFunctionUnitTests
    {
        [Fact]
        public void RTrimFunctionReturnCorrectValueAndValueType()
        {

            RTrimFunction rtrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed ", TokenType.String));
            rtrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("mohamed", Convert.ToString(result.Value));
        }


         [Fact]
        public void RTrimFunctionThrowForEmptyStackArgument()
        {
            RTrimFunction rtrimFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             rtrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void RTrimFunctionReturnNull()
        {
            RTrimFunction rtrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            rtrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void RTrimFunctionThrowForNull()
        {
            RTrimFunction rtrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                rtrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void RTrimFunctionReturnDefaultForNull()
        {
            RTrimFunction rtrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            rtrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}