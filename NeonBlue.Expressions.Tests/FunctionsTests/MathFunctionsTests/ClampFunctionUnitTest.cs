using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class ClampFunctionUnitTest
    {
        [Fact]
        public void ClampFunctionReturnCorrectValueAndValueType()
        {
            ClampFunction clampFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(12.0, TokenType.Double));
            tokens.Push(new Token(4.0, TokenType.Double));
            tokens.Push(new Token(5.0, TokenType.Double));
            clampFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Clamp(12.0,4.0,5.0), Convert.ToDouble(result.Value));
        }
        
        [Fact]
        public void ClampFunctionThrowForEmptyStackArgument()
        {
            ClampFunction clampFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             clampFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
 
        [Fact]
        public void ClampFunctionThrowForInvalidArgument()
        {
            ClampFunction clampFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            tokens.Push(new Token("hello"));
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             clampFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void ClampFunctionReturnNull()
        {
            ClampFunction clampFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            clampFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void ClampFunctionThrowForNull()
        {
            ClampFunction clampFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                clampFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void ClampFunctionReturnDefaultForNull()
        {
            ClampFunction clampFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            clampFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}