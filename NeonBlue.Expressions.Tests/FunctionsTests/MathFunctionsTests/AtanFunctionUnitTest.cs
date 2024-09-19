using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class AtanFunctionUnitTest
    { 
        [Fact]
        public void AtanFunctionReturnCorrectValueAndValueType()
        {
            AtanFunction atanFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            atanFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Atan(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void AtanFunctionThrowForEmptyStackArgument()
        {
            AtanFunction atanFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             atanFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AtanFunctionThrowForInvalidArgument()
        {
            AtanFunction atanFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             atanFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AtanFunctionReturnNull()
        {
            AtanFunction atanFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            atanFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void AtanFunctionThrowForNull()
        {
            AtanFunction atanFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                atanFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void AtanFunctionReturnDefaultForNull()
        {
            AtanFunction atanFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            atanFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}