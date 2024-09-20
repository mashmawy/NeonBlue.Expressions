using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class TurncateFunctionUnitTest
    {
        [Fact]
        public void TurncateFunctionReturnCorrectValueAndValueType()
        {
            TruncateFunction turncateFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            turncateFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Truncate(0.5), Convert.ToDouble(result.Value));
        }
        
        [Fact]
        public void TurncateFunctionThrowForEmptyStackArgument()
        {
            TruncateFunction turncateFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             turncateFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
 
        [Fact]
        public void TurncateFunctionThrowForInvalidArgument()
        {
            TruncateFunction turncateFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             turncateFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void TurncateFunctionReturnNull()
        {
            TruncateFunction turncateFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            turncateFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void TurncateFunctionThrowForNull()
        {
            TruncateFunction turncateFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                turncateFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void TurncateFunctionReturnDefaultForNull()
        {
            TruncateFunction turncateFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            turncateFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}