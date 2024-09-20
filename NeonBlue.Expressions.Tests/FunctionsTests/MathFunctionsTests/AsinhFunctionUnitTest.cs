using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class AsinhFunctionUnitTest
    { 
        [Fact]
        public void AsinhFunctionReturnCorrectValueAndValueType()
        {
            AsinhFunction asinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            asinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Asinh(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void AsinhFunctionThrowForEmptyStackArgument()
        {
            AsinhFunction asinhFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             asinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AsinhFunctionThrowForInvalidArgument()
        {
            AsinhFunction asinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             asinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AsinhFunctionReturnNull()
        {
            AsinhFunction asinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            asinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void AsinhFunctionThrowForNull()
        {
            AsinhFunction asinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                asinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void AsinhFunctionReturnDefaultForNull()
        {
            AsinhFunction asinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            asinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}