using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class PadRightFunctionUnitTests
    {
        [Fact]
        public void PadRightFunctionReturnCorrectValueAndValueType()
        {

            PadRightFunction padRightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("23", TokenType.String));
            tokens.Push(new Token(5, TokenType.Integer));
            tokens.Push(new Token("0", TokenType.String));
            padRightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("23000",Convert.ToString(result.Value));
        }


         [Fact]
        public void PadRightFunctionThrowForEmptyStackArgument()
        {
            PadRightFunction padRightFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
            {
                padRightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }
        
        [Fact]
        public void PadRightFunctionReturnNull()
        {
            PadRightFunction padRightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            padRightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void PadRightFunctionThrowForNull()
        {
            PadRightFunction padRightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                padRightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void PadRightFunctionReturnDefaultForNull()
        {
            PadRightFunction padRightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            padRightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}