
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class ContainFunctionUnitTests
    {
        [Fact]
        public void ContainFunctionReturnCorrectValueAndValueType()
        {

            ContainFunction containFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed hassan ahmed", TokenType.String));
            tokens.Push(new Token("hassan", TokenType.String));
            containFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(bool), result.Value.GetType());
            Assert.True(Convert.ToBoolean(result.Value));
        }


         [Fact]
        public void ContainFunctionThrowForEmptyStackArgument()
        {
            ContainFunction containFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             containFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void ContainFunctionReturnNull()
        {
            ContainFunction containFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            containFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void ContainFunctionThrowForNull()
        {
            ContainFunction containFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                containFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void ContainFunctionReturnDefaultForNull()
        {
            ContainFunction containFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            containFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}