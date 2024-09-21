using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class Log2FunctionUnitTest
    { 
        [Fact]
        public void Log2FunctionReturnCorrectValueAndValueType()
        {
            Log2Function log2Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            log2Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Log2(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void Log2FunctionThrowForEmptyStackArgument()
        {
            Log2Function log2Function = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             log2Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void Log2FunctionThrowForInvalidArgument()
        {
            Log2Function log2Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             log2Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void Log2FunctionReturnNull()
        {
            Log2Function log2Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            log2Function.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void Log2FunctionThrowForNull()
        {
            Log2Function log2Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                log2Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void Log2FunctionReturnDefaultForNull()
        {
            Log2Function log2Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            log2Function.Update(tokens, new ExecutionOptions(NullStrategy.Default));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}