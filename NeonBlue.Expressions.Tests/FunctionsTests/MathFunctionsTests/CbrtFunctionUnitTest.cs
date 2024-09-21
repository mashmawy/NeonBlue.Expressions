using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class CbrtFunctionUnitTest
    { 
        [Fact]
        public void CbrtFunctionReturnCorrectValueAndValueType()
        {
            CbrtFunction cbrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            cbrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Cbrt(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void CbrtFunctionThrowForEmptyStackArgument()
        {
            CbrtFunction cbrtFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             cbrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void CbrtFunctionThrowForInvalidArgument()
        {
            CbrtFunction cbrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             cbrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void CbrtFunctionReturnNull()
        {
            CbrtFunction cbrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            cbrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void CbrtFunctionThrowForNull()
        {
            CbrtFunction cbrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                cbrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void CbrtFunctionReturnDefaultForNull()
        {
            CbrtFunction cbrtFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            cbrtFunction.Update(tokens, new ExecutionOptions(NullStrategy.Default));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}