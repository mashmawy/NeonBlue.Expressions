using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class SqrtFunctionUnitTest
    { 
        [Fact]
        public void SqrtFunctionReturnCorrectValueAndValueType()
        {
            SqrtFunction sqrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            sqrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Sqrt(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void SqrtFunctionThrowForEmptyStackArgument()
        {
            SqrtFunction sqrtFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             sqrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void SqrtFunctionThrowForInvalidArgument()
        {
            SqrtFunction sqrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             sqrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void SqrtFunctionReturnNull()
        {
            SqrtFunction sqrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            sqrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void SqrtFunctionThrowForNull()
        {
            SqrtFunction sqrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                sqrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void SqrtFunctionReturnDefaultForNull()
        {
            SqrtFunction sqrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            sqrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}