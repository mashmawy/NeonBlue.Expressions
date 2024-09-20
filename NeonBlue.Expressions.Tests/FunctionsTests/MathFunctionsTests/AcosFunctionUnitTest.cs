using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class AcosFunctionUnitTest
    { 
        [Fact]
        public void AcosFunctionReturnCorrectValueAndValueType()
        {
            AcosFunction acosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(150, TokenType.Integer));
            acosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Acos(150), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void AcosFunctionThrowForEmptyStackArgument()
        {
            AcosFunction acosFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             acosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AcosFunctionThrowForInvalidArgument()
        {
            AcosFunction acosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
         {
             acosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AcosFunctionReturnNull()
        {
            AcosFunction acosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            acosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void AcosFunctionThrowForNull()
        {
            AcosFunction acosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                acosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void AcosFunctionReturnDefaultForNull()
        {
            AcosFunction acosFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            acosFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}