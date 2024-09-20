using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class PadLeftFunctionUnitTests
    {
        [Fact]
        public void PadLeftFunctionReturnCorrectValueAndValueType()
        {

            PadLeftFunction padLeftFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("23", TokenType.String));
            tokens.Push(new Token(5, TokenType.Integer));
            tokens.Push(new Token("0", TokenType.String));
            padLeftFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("00023",Convert.ToString(result.Value));
        }


         [Fact]
        public void PadLeftFunctionThrowForEmptyStackArgument()
        {
            PadLeftFunction padLeftFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
            {
                padLeftFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }
        
        [Fact]
        public void PadLeftFunctionReturnNull()
        {
            PadLeftFunction padLeftFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            padLeftFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void PadLeftFunctionThrowForNull()
        {
            PadLeftFunction padLeftFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                padLeftFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void PadLeftFunctionReturnDefaultForNull()
        {
            PadLeftFunction padLeftFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            padLeftFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}