
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class ReplaceFunctionUnitTests
    {
        [Fact]
        public void ReplaceFunctionReturnCorrectValueAndValueType()
        {

            ReplaceFunction replaceFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed-hassan", TokenType.String));
            tokens.Push(new Token("-", TokenType.String));
            tokens.Push(new Token(" ", TokenType.String));
            replaceFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("mohamed hassan",Convert.ToString(result.Value));
        }


         [Fact]
        public void ReplaceFunctionThrowForEmptyStackArgument()
        {
            ReplaceFunction replaceFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
            {
                replaceFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }
        
        [Fact]
        public void ReplaceFunctionReturnNull()
        {
            ReplaceFunction replaceFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            replaceFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void ReplaceFunctionThrowForNull()
        {
            ReplaceFunction replaceFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                replaceFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void ReplaceFunctionReturnDefaultForNull()
        {
            ReplaceFunction replaceFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            replaceFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}