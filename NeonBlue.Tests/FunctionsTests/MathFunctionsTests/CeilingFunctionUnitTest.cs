using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class CeilingFunctionUnitTest
    { 
        [Fact]
        public void CeilingFunctionReturnCorrectValueAndValueType()
        {
            CeilingFunction ceilingFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(2.5, TokenType.Double));
            ceilingFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Ceiling(2.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void CeilingFunctionThrowForEmptyStackArgument()
        {
            CeilingFunction ceilingFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             ceilingFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void CeilingFunctionThrowForInvalidArgument()
        {
            CeilingFunction ceilingFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             ceilingFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void CeilingFunctionReturnNull()
        {
            CeilingFunction ceilingFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            ceilingFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void CeilingFunctionThrowForNull()
        {
            CeilingFunction ceilingFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                ceilingFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void CeilingFunctionReturnDefaultForNull()
        {
            CeilingFunction ceilingFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            ceilingFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}