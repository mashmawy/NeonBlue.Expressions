using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class TanhFunctionUnitTest
    { 
        [Fact]
        public void TanhFunctionReturnCorrectValueAndValueType()
        {
            TanhFunction tanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            tanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Tanh(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void TanhFunctionThrowForEmptyStackArgument()
        {
            TanhFunction tanhFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             tanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void TanhFunctionThrowForInvalidArgument()
        {
            TanhFunction tanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             tanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void TanhFunctionReturnNull()
        {
            TanhFunction tanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void TanhFunctionThrowForNull()
        {
            TanhFunction tanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                tanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void TanhFunctionReturnDefaultForNull()
        {
            TanhFunction tanhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tanhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}