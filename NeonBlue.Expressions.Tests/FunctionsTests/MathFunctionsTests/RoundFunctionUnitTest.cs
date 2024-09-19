using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class RoundFunctionUnitTest
    { 
        [Fact]
        public void RoundFunctionReturnCorrectValueAndValueType()
        {
            RoundFunction roundFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(10.5, TokenType.Double));
            tokens.Push(new Token(2, TokenType.Double));
            roundFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Round(10.5,2), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void RoundFunctionThrowForEmptyStackArgument()
        {
            RoundFunction roundFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             roundFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void RoundFunctionThrowForInvalidArgument()
        {
            RoundFunction roundFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             roundFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void RoundFunctionReturnNull()
        {
            RoundFunction roundFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            roundFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void RoundFunctionThrowForNull()
        {
            RoundFunction roundFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                roundFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void RoundFunctionReturnDefaultForNull()
        {
            RoundFunction roundFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            roundFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}