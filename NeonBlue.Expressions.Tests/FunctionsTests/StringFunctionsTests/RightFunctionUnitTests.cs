
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class RightFunctionUnitTests
    {
        [Fact]
        public void RightFunctionReturnCorrectValueAndValueType()
        {
            RightFunction rightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed hassan ahmed", TokenType.String));
            tokens.Push(new Token(3, TokenType.Integer));
            rightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("med", Convert.ToString(result.Value));
        }


         [Fact]
        public void RightFunctionThrowForEmptyStackArgument()
        {
            RightFunction rightFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackExecption>(() =>
         {
             rightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void RightFunctionReturnNull()
        {
            RightFunction rightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            rightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void RightFunctionThrowForNull()
        {
            RightFunction rightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                rightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void RightFunctionReturnDefaultForNull()
        {
            RightFunction rightFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            rightFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}