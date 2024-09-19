
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class LowerFunctionUnitTests
    {
        [Fact]
        public void LowerFunctionReturnCorrectValueAndValueType()
        {

            LowerFunction lowerFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("MohAmed", TokenType.String));
            lowerFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("mohamed", Convert.ToString(result.Value));
        }


         [Fact]
        public void LowerFunctionThrowForEmptyStackArgument()
        {
            LowerFunction lowerFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             lowerFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void LowerFunctionReturnNull()
        {
            LowerFunction lowerFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            lowerFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void LowerFunctionThrowForNull()
        {
            LowerFunction lowerFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                lowerFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void LowerFunctionReturnDefaultForNull()
        {
            LowerFunction lowerFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            lowerFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}