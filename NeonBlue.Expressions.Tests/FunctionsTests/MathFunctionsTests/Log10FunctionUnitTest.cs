using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class Log10FunctionUnitTest
    { 
        [Fact]
        public void Log10FunctionReturnCorrectValueAndValueType()
        {
            Log10Function log10Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            log10Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Log10(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void Log10FunctionThrowForEmptyStackArgument()
        {
            Log10Function log10Function = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             log10Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void Log10FunctionThrowForInvalidArgument()
        {
            Log10Function log10Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             log10Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void Log10FunctionReturnNull()
        {
            Log10Function log10Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            log10Function.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void Log10FunctionThrowForNull()
        {
            Log10Function log10Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                log10Function.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void Log10FunctionReturnDefaultForNull()
        {
            Log10Function log10Function = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            log10Function.Update(tokens, new ExecutionOptions(NullStrategy.Default));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}