using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class SinhFunctionUnitTest
    { 
        [Fact]
        public void SinhFunctionReturnCorrectValueAndValueType()
        {
            SinhFunction sinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            sinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Sinh(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void SinhFunctionThrowForEmptyStackArgument()
        {
            SinhFunction sinhFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             sinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void SinhFunctionThrowForInvalidArgument()
        {
            SinhFunction sinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             sinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void SinhFunctionReturnNull()
        {
            SinhFunction sinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            sinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void SinhFunctionThrowForNull()
        {
            SinhFunction sinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                sinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void SinhFunctionReturnDefaultForNull()
        {
            SinhFunction sinhFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            sinhFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}