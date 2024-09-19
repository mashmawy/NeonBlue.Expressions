using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class AcoshFunctionUnitTest
    { 
        [Fact]
        public void AcoshFunctionReturnCorrectValueAndValueType()
        {
            AcoshFunction acoshFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(150, TokenType.Integer));
            acoshFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Acosh(150), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void AcoshFunctionThrowForEmptyStackArgument()
        {
            AcoshFunction acoshFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             acoshFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AcoshFunctionThrowForInvalidArgument()
        {
            AcoshFunction acoshFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             acoshFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void AcoshFunctionReturnNull()
        {
            AcoshFunction acoshFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            acoshFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void AcoshFunctionThrowForNull()
        {
            AcoshFunction acoshFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                acoshFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void AcoshFunctionReturnDefaultForNull()
        {
            AcoshFunction acoshFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            acoshFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}