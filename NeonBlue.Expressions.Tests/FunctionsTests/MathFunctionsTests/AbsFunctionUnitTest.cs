using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class AbsFunctionUnitTest
    {

        [Fact]
        public void AbsFunctionReturnCorrectValueAndValueType()
        {
            AbsFunction absFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(-1, TokenType.Integer));
            absFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Integer);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(int), result.Value.GetType());
            Assert.Equal(Math.Abs(-1), Convert.ToInt32(result.Value));
        }
        [Fact]
        public void AbsFunctionThrowForEmptyStackArgument()
        {
            AbsFunction absFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             absFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AbsFunctionThrowForInvalidArgument()
        {
            AbsFunction absFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             absFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AbsFunctionReturnNull()
        {
            AbsFunction absFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            absFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void AbsFunctionThrowForNull()
        {
            AbsFunction absFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                absFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void AbsFunctionReturnDefaultForNull()
        {

            AbsFunction absFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            absFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}