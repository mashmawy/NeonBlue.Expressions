
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class EndWithFunctionUnitTests
    {
        [Fact]
        public void EndWithFunctionReturnCorrectValueAndValueType()
        {

            EndWithFunction endWithFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed hassan ahmed", TokenType.String));
            tokens.Push(new Token("ahmed", TokenType.String));
            endWithFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(bool), result.Value.GetType());
            Assert.True(Convert.ToBoolean(result.Value));
        }


         [Fact]
        public void EndWithFunctionThrowForEmptyStackArgument()
        {
            EndWithFunction endWithFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             endWithFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void EndWithFunctionReturnNull()
        {
            EndWithFunction endWithFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            endWithFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void EndWithFunctionThrowForNull()
        {
            EndWithFunction endWithFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenExecption>(() =>
            {
                endWithFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void EndWithFunctionReturnDefaultForNull()
        {
            EndWithFunction endWithFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            endWithFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}