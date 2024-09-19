using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class CosFunctionUnitTest
    { 
        [Fact]
        public void CosFunctionReturnCorrectValueAndValueType()
        {
            CosFunction cosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            cosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Cos(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void CosFunctionThrowForEmptyStackArgument()
        {
            CosFunction cosFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             cosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void CosFunctionThrowForInvalidArgument()
        {
            CosFunction cosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             cosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void CosFunctionReturnNull()
        {
            CosFunction cosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            cosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void CosFunctionThrowForNull()
        {
            CosFunction cosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                cosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void CosFunctionReturnDefaultForNull()
        {
            CosFunction cosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            cosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}