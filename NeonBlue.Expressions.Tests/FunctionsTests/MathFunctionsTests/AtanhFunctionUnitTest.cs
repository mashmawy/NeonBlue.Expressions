using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class AtanhFunctionUnitTest
    { 
        [Fact]
        public void AtanhFunctionReturnCorrectValueAndValueType()
        {
            AtanhFunction atanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            atanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Atanh(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void AtanhFunctionThrowForEmptyStackArgument()
        {
            AtanhFunction atanhFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             atanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AtanhFunctionThrowForInvalidArgument()
        {
            AtanhFunction atanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             atanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AtanhFunctionReturnNull()
        {
            AtanhFunction atanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            atanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void AtanhFunctionThrowForNull()
        {
            AtanhFunction atanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                atanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void AtanhFunctionReturnDefaultForNull()
        {
            AtanhFunction atanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            atanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}