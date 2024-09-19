using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.MathFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.MathFunctionsTests
{
    public class FloorFunctionUnitTest
    { 
        [Fact]
        public void FloorFunctionReturnCorrectValueAndValueType()
        {
            FloorFunction floorFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(0.5, TokenType.Double));
            floorFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Double);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(double), result.Value.GetType());
            Assert.Equal(Math.Floor(0.5), Convert.ToDouble(result.Value));
        }
        [Fact]
        public void FloorFunctionThrowForEmptyStackArgument()
        {
            FloorFunction floorFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             floorFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void FloorFunctionThrowForInvalidArgument()
        {
            FloorFunction floorFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeExeception>(() =>
         {
             floorFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        [Fact]
        public void FloorFunctionReturnNull()
        {
            FloorFunction floorFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            floorFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void FloorFunctionThrowForNull()
        {
            FloorFunction floorFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                floorFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void FloorFunctionReturnDefaultForNull()
        {
            FloorFunction floorFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            floorFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}