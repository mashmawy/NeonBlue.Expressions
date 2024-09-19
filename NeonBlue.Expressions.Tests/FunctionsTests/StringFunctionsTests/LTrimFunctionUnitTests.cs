
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class LTrimFunctionUnitTests
    {
        [Fact]
        public void LTrimFunctionReturnCorrectValueAndValueType()
        {

            LTrimFunction ltrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(" mohamed", TokenType.String));
            ltrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("mohamed", Convert.ToString(result.Value));
        }


         [Fact]
        public void LTrimFunctionThrowForEmptyStackArgument()
        {
            LTrimFunction ltrimFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             ltrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void LTrimFunctionReturnNull()
        {
            LTrimFunction ltrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            ltrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void LTrimFunctionThrowForNull()
        {
            LTrimFunction ltrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                ltrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void LTrimFunctionReturnDefaultForNull()
        {
            LTrimFunction ltrimFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            ltrimFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}