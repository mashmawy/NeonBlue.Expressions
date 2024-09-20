using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class PowFunctionUnitTest
    {
        [Fact]
        public void PowFunctionReturnCorrectValueAndValueType()
        {
            PowFunction powFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            tokens.Push(new Token(12, TokenType.Double));
            powFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Pow(0.5,12), Convert.ToDouble(result.Value));
        }
        
        [Fact]
        public void PowFunctionThrowForEmptyStackArgument()
        {
            PowFunction powFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             powFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
 
        [Fact]
        public void PowFunctionThrowForInvalidArgument()
        {
            PowFunction powFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             powFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void PowFunctionReturnNull()
        {
            PowFunction powFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            powFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void PowFunctionThrowForNull()
        {
            PowFunction powFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                powFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void PowFunctionReturnDefaultForNull()
        {
            PowFunction powFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            powFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}